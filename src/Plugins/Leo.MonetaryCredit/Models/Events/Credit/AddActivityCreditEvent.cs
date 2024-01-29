using Leo.MonetaryCredit.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.Events
{
    public class AddActivityCreditEvent : INotification
    {
        public AddActivityCreditEvent(CustomerActivityCreditRecordList customerActivityCreditRecordList)
        {
            CustomerActivityCreditRecordList = customerActivityCreditRecordList;
        }

        /// <summary>
        /// 活动积分变动记录
        /// </summary>
        public CustomerActivityCreditRecordList CustomerActivityCreditRecordList { get; set; }

    }
}
