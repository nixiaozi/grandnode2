using Grand.Business.Core.Utilities.Checkout;
using Grand.Domain;
using Grand.Domain.Payments;
using Leo.MonetaryCredit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Services
{
    public interface IMonetaryCreditService
    {
        /// <summary>
        /// 获取用户的信用货币相关信息
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public Task<CustomerBalanceData>  GetUserMonetaryCreditData(string CustomerId);


        /// <summary>
        /// 进行支付的操作(添加)
        /// </summary>
        /// <param name="paymentTransaction"></param>
        /// <returns></returns>
        public Task<ProcessPaymentResult> MonetaryCreditPayment(PaymentTransaction paymentTransaction);


        /// <summary>
        /// 创建信用货币信用订单
        /// </summary>
        /// <returns></returns>
        public Task MonetaryCreditOrderCreate(MonetaryCreditOrder monetaryCreditOrder);


        /// <summary>
        /// 撤回信用货币信用订单
        /// </summary>
        /// <returns></returns>
        public Task MonetaryCreditOrderRecalled(string orderId);




        /// <summary>
        /// 创建第三方信用货币充值订单
        /// </summary>
        /// <param name="thirdBalanceRechangeOrder"></param>
        /// <returns></returns>
        public Task ThirdBanlanceRechangOrderCreate(ThirdBalanceRechangeOrder thirdBalanceRechangeOrder);


        /// <summary>
        /// 撤回第三方信用货币充值订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task ThirdBanlanceRechangOrderRecall(string orderId);



        /// <summary>
        /// 获取用户信用货币账户的历史变动记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<IPagedList<CustomerBalanceRecordList>> GetCustomerBalanceRecords(string customerId, int pageIndex = 0, int pageSize = int.MaxValue);



        /// <summary>
        /// 创建新的用户活动积分记录
        /// </summary>
        /// <param name="customerActivityCreditRecordList"></param>
        /// <returns></returns>
        public Task CustomerActivityCreditCreate(CustomerActivityCreditRecordList customerActivityCreditRecordList);


        /// <summary>
        /// 获取用户的活动积分变动记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<IPagedList<CustomerActivityCreditRecordList>> GetCustomerActivityCreditRecords(string customerId, int pageIndex = 0, int pageSize = int.MaxValue);





        /// <summary>
        /// 创建新的用户购买积分记录
        /// </summary>
        /// <param name="customerBuyCreditRecordList"></param>
        /// <returns></returns>
        public Task CustomerBuyCreditCreate(CustomerBuyCreditRecordList customerBuyCreditRecordList);

        /// <summary>
        /// 获取用户的购买积分变动记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<IPagedList<CustomerBuyCreditRecordList>> GetCustomerBuyCreditRecords(string customerId, int pageIndex = 0, int pageSize = int.MaxValue);





        /// <summary>
        /// 创建新的用户销售积分记录
        /// </summary>
        /// <param name="customerSellCreditRecordList"></param>
        /// <returns></returns>
        public Task CustomerSellCreditCreate(CustomerSellCreditRecordList customerSellCreditRecordList);

        /// <summary>
        /// 获取用户的销售记录变动记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<IPagedList<CustomerSellCreditRecordList>> GetCustomerSellCreditRecords(string customerId, int pageIndex = 0, int pageSize = int.MaxValue);


    }
}
