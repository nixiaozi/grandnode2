using Grand.Business.Core.Interfaces.Customers;
using Grand.Business.Core.Utilities.Checkout;
using Grand.Domain.Data;
using Grand.Domain.Payments;
using Leo.MonetaryCredit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Leo.MonetaryCredit.Services
{
    public class MonetaryCreditService : IMonetaryCreditService
    {
        private readonly ICustomerService _customerService;
        private readonly IRepository<CustomerBalanceRechangeList> _customerRechangeListRepository;
        private readonly IRepository<CustomerBalanceData> _customerCreditDataRepository;
        private readonly IRepository<CustomerSellCreditRecordList> _customerSellCreditListRepository;
        private readonly IRepository<CustomerActivityCreditRecordList> _customerActivityCreditListRepository;
        private readonly IRepository<CustomerBuyCreditRecordList> _customerBuyCreditListRepository;
        


        public MonetaryCreditService(
            ICustomerService customerService,
            IRepository<CustomerBalanceRechangeList> customerRechangeListRepository,
            IRepository<CustomerBalanceData> customerCreditDataRepository,
            IRepository<CustomerSellCreditRecordList> customerSellCreditListRepository,
            IRepository<CustomerActivityCreditRecordList> customerActivityCreditListRepository,
            IRepository<CustomerBuyCreditRecordList> customerBuyCreditListRepository) 
        {
            _customerService = customerService;
            _customerRechangeListRepository = customerRechangeListRepository;
            _customerCreditDataRepository = customerCreditDataRepository;
            _customerSellCreditListRepository = customerSellCreditListRepository;
            _customerActivityCreditListRepository = customerActivityCreditListRepository;
            _customerBuyCreditListRepository = customerBuyCreditListRepository;

        }

        /// <summary>
        /// 获取用户相关信用货币数据
        /// </summary>
        /// <param name="CustomerGuid"></param>
        /// <returns></returns>
        public async Task<CustomerBalanceData> GetUserMonetaryCreditData(string CustomerGuid)
        {
            var result = await Task.FromResult(await _customerCreditDataRepository.GetByIdAsync(CustomerGuid));

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


            
           var rechangeListResult = await  _customerRechangeListRepository.InsertAsync(new CustomerBalanceRechangeList {
                CreateDateTime = DateTime.Now,
                CustomerID = paymentTransaction.CustomerId,
                RechangeChangeID = paymentTransaction.OrderCode,
                RechangeMoney = (decimal)paymentTransaction.TransactionAmount,
                ReleateId = lastRecord?.Id,
                ResultMoney = userMonetaryCreditData.CurrentBalanceRemain - (decimal)paymentTransaction.TransactionAmount,
                TheRechangeStatus = Query.RechangeStatus.Done,
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



        public async Task UserUpdateCreditAmount(string CustomerGuid, decimal Amount, string UpdateType)
        {
            throw new NotImplementedException();
        }



        public Task UserUpdateRechangeAmount(string CustomerGuid, decimal Amount, string UpdateType)
        {
            throw new NotImplementedException();
        }
    }
}
