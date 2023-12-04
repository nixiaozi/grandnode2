using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.Events
{
    public class RecallSellCreditEvent : INotification
    {
        /// <summary>
        /// 需要撤回的订单编号
        /// </summary>
        public string RechangeId { get;set; }

    }
}
