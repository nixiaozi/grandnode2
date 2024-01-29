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
    public class AddBuyCreditHandler : INotificationHandler<AddBuyCreditEvent>
    {
        private readonly IRepository<CustomerBuyCreditRecordList> _customerBuyCreditRecordList;

        public AddBuyCreditHandler(IRepository<CustomerBuyCreditRecordList> customerBuyCreditRecordList)
        {
            _customerBuyCreditRecordList= customerBuyCreditRecordList;


        }


        public async Task Handle(AddBuyCreditEvent notification, CancellationToken cancellationToken)
        {
            

            await _customerBuyCreditRecordList.InsertAsync(notification.CustomerBuyCreditRecordList);

            // 

        }
    }
}
