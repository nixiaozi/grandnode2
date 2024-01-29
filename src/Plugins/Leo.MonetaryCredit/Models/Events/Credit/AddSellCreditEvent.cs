using Leo.MonetaryCredit.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.Events
{
    public class AddSellCreditEvent : INotification
    {

        public AddSellCreditEvent(CustomerSellCreditRecordList customerSellCreditRecordList)
        {
            CustomerSellCreditRecordLists = customerSellCreditRecordList;
        }

        /// <summary>
        /// 用户销售积分变动记录
        /// </summary>
        public CustomerSellCreditRecordList CustomerSellCreditRecordLists { get;set; }

    }
}
