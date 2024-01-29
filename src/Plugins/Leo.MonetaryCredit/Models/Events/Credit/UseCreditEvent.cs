using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.Events
{
    public class UseCreditEvent : INotification
    {
        public UseCreditEvent(decimal creditAmount,string creditType)
        {
            CreditAmount = creditAmount;
            CreditType = creditType;
        }


        /// <summary>
        /// 需要撤回的订单编号
        /// </summary>
        public decimal CreditAmount { get;set; }

        /// <summary>
        /// 使用的积分类型
        /// </summary>
        public string CreditType { get; set; }

    }
}
