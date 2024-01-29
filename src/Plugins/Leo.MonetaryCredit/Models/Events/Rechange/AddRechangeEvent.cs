using Leo.MonetaryCredit.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.Events
{
    public class AddRechangeEvent : INotification
    {
        public AddRechangeEvent(CustomerBalanceRecordList customerBalanceRecordList)
        {
            CustomerBalanceRecordList = customerBalanceRecordList;
        }


        /// <summary>
        /// 信用货币余额账户余额增加的变动记录
        /// </summary>
        public CustomerBalanceRecordList CustomerBalanceRecordList { get;set; }

    }
}
