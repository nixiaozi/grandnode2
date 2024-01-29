using Grand.Domain.Data;
using Grand.Infrastructure.Events;
using Leo.MonetaryCredit.Domain;
using Leo.MonetaryCredit.Models.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Infrastructure.Handler
{
    public class RecallActivityCreditHandler : INotificationHandler<RecallActivityCreditEvent>
    {
        private readonly IRepository<CustomerActivityCreditRecordList> _customerActivityCreditRecordList;

        public RecallActivityCreditHandler(IRepository<CustomerActivityCreditRecordList> customerActivityCreditRecordList)
        {
            _customerActivityCreditRecordList = customerActivityCreditRecordList;


        }


        public async Task Handle(RecallActivityCreditEvent notification, CancellationToken cancellationToken)
        {
            

            // 

        }
    }
}
