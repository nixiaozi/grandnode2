using Grand.Business.Core.Interfaces.Customers;
using Grand.Business.Core.Utilities.Checkout;
using Grand.Domain;
using Grand.Domain.Data;
using Grand.Domain.Payments;
using Grand.Infrastructure.Extensions;
using Leo.MonetaryCredit.Domain;
using MassTransit.Mediator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static MassTransit.ValidationResultExtensions;
using IMediator = MediatR.IMediator;

namespace Leo.MonetaryCredit.Services
{
    public class MonetaryCreditService : IMonetaryCreditService
    {
        private readonly ICustomerService _customerService;
        private readonly IRepository<CustomerBalanceRecordList> _customerRechangeListRepository;
        private readonly IRepository<CustomerBalanceData> _customerCreditDataRepository;
        private readonly IRepository<CustomerSellCreditRecordList> _customerSellCreditListRepository;
        private readonly IRepository<CustomerActivityCreditRecordList> _customerActivityCreditListRepository;
        private readonly IRepository<CustomerBuyCreditRecordList> _customerBuyCreditListRepository;
        private readonly IRepository<MonetaryCreditOrder> _monetaryCreditOrderRepository;
        private readonly IRepository<ThirdBalanceRechangeOrder> _thirdBalanceRechangeOrderRepository;
        private readonly IMediator _mediator;



        public MonetaryCreditService(
            ICustomerService customerService,
            IRepository<CustomerBalanceRecordList> customerRechangeListRepository,
            IRepository<CustomerBalanceData> customerCreditDataRepository,
            IRepository<CustomerSellCreditRecordList> customerSellCreditListRepository,
            IRepository<CustomerActivityCreditRecordList> customerActivityCreditListRepository,
            IRepository<CustomerBuyCreditRecordList> customerBuyCreditListRepository,
            IRepository<MonetaryCreditOrder> monetaryCreditOrderRepository,
            IRepository<ThirdBalanceRechangeOrder> thirdBalanceRechangeOrderRepository,
        IMediator mediator) 
        {
            _customerService = customerService;
            _customerRechangeListRepository = customerRechangeListRepository;
            _customerCreditDataRepository = customerCreditDataRepository;
            _customerSellCreditListRepository = customerSellCreditListRepository;
            _customerActivityCreditListRepository = customerActivityCreditListRepository;
            _customerBuyCreditListRepository = customerBuyCreditListRepository;
            _monetaryCreditOrderRepository = monetaryCreditOrderRepository;
            _thirdBalanceRechangeOrderRepository = thirdBalanceRechangeOrderRepository;
            _mediator = mediator;

        }

        /// <summary>
        /// 获取用户相关信用货币数据
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<CustomerBalanceData> GetUserMonetaryCreditData(string CustomerId)
        {
            var result = _customerCreditDataRepository.Table.FirstOrDefault(s=>s.Id==CustomerId);

            if (result == null)
            {
                result = new CustomerBalanceData {
                    ActionCreditRemain = 0,
                    TotalUsedActionCredit = 0,
                    BuyCreditRemain = 0,
                    CurrentBalanceRemain = 0,
                    TotalRechangeByCredit = 0,
                    TotalRechangeByThird = 0,
                    CustomerID = CustomerId,
                    SellCreditRemain = 0,
                    TotalUsedSellCredit = 0,
                    UserCreditScore = 0,
                    TotalUsedBuyCredit = 0,
                    CreateDate = DateTime.Now,
                };

                await _customerCreditDataRepository.InsertAsync(result);

                //event notification
                await _mediator.EntityInserted(result);

            }

            return result;
        }

        /// <summary>
        /// 信用货币支付
        /// </summary>
        /// <param name="paymentTransaction"></param>
        /// <returns></returns>
        public async Task<ProcessPaymentResult> MonetaryCreditPayment(PaymentTransaction paymentTransaction)
        {
            var processPaymentResult = new ProcessPaymentResult();
            // 确认是余额足够
            var userMonetaryCreditData =await GetUserMonetaryCreditData(paymentTransaction.CustomerId);

            if ((double)userMonetaryCreditData.CurrentBalanceRemain < paymentTransaction.PaidAmount)
            {
                processPaymentResult.AddError("账户余额不足");
                return processPaymentResult;
            }

            // 添加支付记录
            var lastRecord = _customerRechangeListRepository.Table.OrderByDescending(s => s.CreateDateTime)
                .FirstOrDefault(s => s.CustomerID == paymentTransaction.CustomerId);


            if (lastRecord != null)
            {
                // 确认当前金额是否一致
                if(lastRecord.ResultMoney!= userMonetaryCreditData.CurrentBalanceRemain)
                {
                    processPaymentResult.AddError("账户异常无法交易,错误代码100001");
                    return processPaymentResult;
                }

            }
            else
            {
                if (userMonetaryCreditData.CurrentBalanceRemain!=0m)
                {
                    processPaymentResult.AddError("账户异常无法交易,错误代码100002");
                    return processPaymentResult;
                }
            }


            
           var rechangeListResult = await  _customerRechangeListRepository.InsertAsync(new CustomerBalanceRecordList {
                CreateDateTime = DateTime.Now,
                CustomerID = paymentTransaction.CustomerId,
                ChangeOrderID = paymentTransaction.OrderCode,
                ChangeMoney = (decimal)paymentTransaction.TransactionAmount,
                LastID = lastRecord?.Id,
                ResultMoney = userMonetaryCreditData.CurrentBalanceRemain - (decimal)paymentTransaction.TransactionAmount,
                
            });


            userMonetaryCreditData.CurrentBalanceRemain = userMonetaryCreditData.CurrentBalanceRemain - (decimal)paymentTransaction.TransactionAmount;

            var creditDataResult = await _customerCreditDataRepository.UpdateAsync(userMonetaryCreditData);

            if (rechangeListResult.ResultMoney == creditDataResult.CurrentBalanceRemain)
            {
                processPaymentResult.PaidAmount = paymentTransaction.TransactionAmount;
                processPaymentResult.NewPaymentTransactionStatus = Grand.Domain.Payments.TransactionStatus.Paid;
            }
            else
            {
                processPaymentResult.AddError("账户交易出错,错误代码100003");
            }

            return processPaymentResult;
        }


        /// <summary>
        /// 创建信用货币信用订单
        /// </summary>
        /// <returns></returns>
        public async Task MonetaryCreditOrderCreate(MonetaryCreditOrder monetaryCreditOrder)
        {


            throw new NotImplementedException();
        }

        /// <summary>
        /// 撤回信用货币信用订单
        /// </summary>
        /// <returns></returns>
        public Task MonetaryCreditOrderRecalled(string orderId)
        {

            throw new NotImplementedException();
        }


        /// <summary>
        /// 创建第三方信用货币充值订单
        /// </summary>
        /// <param name="thirdBalanceRechangeOrder"></param>
        /// <returns></returns>
        public Task ThirdBanlanceRechangOrderCreate(ThirdBalanceRechangeOrder thirdBalanceRechangeOrder)
        {

            throw new NotImplementedException();

        }


        /// <summary>
        /// 撤回第三方信用货币充值订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task ThirdBanlanceRechangOrderRecall(string orderId)
        {


            throw new NotImplementedException();
        }


        /// <summary>
        /// 获取用户信用货币账户的历史变动记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<IPagedList<CustomerBalanceRecordList>> GetCustomerBalanceRecords(string customerId, int pageIndex = 0, int pageSize = int.MaxValue)
        {

            throw new NotImplementedException();
        }


        /// <summary>
        /// 创建新的用户活动积分记录
        /// </summary>
        /// <param name="customerActivityCreditRecordList"></param>
        /// <returns></returns>
        public Task CustomerActivityCreditCreate(CustomerActivityCreditRecordList customerActivityCreditRecordList)
        {


            throw new NotImplementedException();
        }


        /// <summary>
        /// 获取用户的活动积分变动记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<IPagedList<CustomerActivityCreditRecordList>> GetCustomerActivityCreditRecords(string customerId, int pageIndex = 0, int pageSize = int.MaxValue)
        {


            throw new NotImplementedException();
        }


        /// <summary>
        /// 创建新的用户购买积分记录
        /// </summary>
        /// <param name="customerBuyCreditRecordList"></param>
        /// <returns></returns>
        public Task CustomerBuyCreditCreate(CustomerBuyCreditRecordList customerBuyCreditRecordList)
        {


            throw new NotImplementedException();
        }


        /// <summary>
        /// 获取用户的购买积分变动记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<IPagedList<CustomerBuyCreditRecordList>> GetCustomerBuyCreditRecords(string customerId, int pageIndex = 0, int pageSize = int.MaxValue)
        {


            throw new NotImplementedException();
        }



        /// <summary>
        /// 创建新的用户销售积分记录
        /// </summary>
        /// <param name="customerSellCreditRecordList"></param>
        /// <returns></returns>
        public Task CustomerSellCreditCreate(CustomerSellCreditRecordList customerSellCreditRecordList)
        {


            throw new NotImplementedException();
        }



        /// <summary>
        /// 获取用户的销售记录变动记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<IPagedList<CustomerSellCreditRecordList>> GetCustomerSellCreditRecords(string customerId, int pageIndex = 0, int pageSize = int.MaxValue)
        {


            throw new NotImplementedException();
        }




    }
}
