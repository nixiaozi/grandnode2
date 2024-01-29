using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.Events
{
    public class RecallActivityCreditEvent : INotification
    {
        public RecallActivityCreditEvent(string recordID)
        {
            RecordID = recordID;
        }

        /// <summary>
        /// 要撤回的记录编号
        /// </summary>
        public string RecordID { get;set; }

    }
}
