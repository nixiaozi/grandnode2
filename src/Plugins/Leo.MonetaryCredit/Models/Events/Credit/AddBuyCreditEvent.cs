using Leo.MonetaryCredit.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.Events
{
    public class AddBuyCreditEvent : INotification
    {
        public AddBuyCreditEvent(CustomerBuyCreditRecordList customerBuyCreditRecordList)
        {
            CustomerBuyCreditRecordList= customerBuyCreditRecordList;
        }


        /// <summary>
        /// 用户购买积分变动记录
        /// </summary>
        public CustomerBuyCreditRecordList CustomerBuyCreditRecordList { get;set; }

    }
}
