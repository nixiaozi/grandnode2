using Grand.Business.Core.Utilities.Checkout;
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



        public Task<ProcessPaymentResult> MonetaryCreditPayment(PaymentTransaction paymentTransaction);



        /// <summary>
        /// 更新用户的信用货币余额
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="Amount"></param>
        /// <param name="UpdateType"></param>
        /// <returns></returns>
        public Task UserUpdateRechangeAmount(string CustomerId, decimal Amount,string UpdateType);

        /// <summary>
        /// 更新用户的积分余额
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="Amount"></param>
        /// <param name="UpdateType"></param>
        /// <returns></returns>
        public Task UserUpdateCreditAmount(string CustomerId, decimal Amount, string UpdateType);



    }
}
