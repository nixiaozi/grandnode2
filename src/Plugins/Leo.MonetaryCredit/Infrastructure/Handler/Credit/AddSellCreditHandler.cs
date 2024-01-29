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
    public class AddSellCreditHandler : INotificationHandler<AddSellCreditEvent>
    {
        private readonly IRepository<CustomerSellCreditRecordList> _customerSellCreditRecordList;

        public AddSellCreditHandler(IRepository<CustomerSellCreditRecordList> customerSellCreditRecordList)
        {
            _customerSellCreditRecordList = customerSellCreditRecordList;


        }


        public async Task Handle(AddSellCreditEvent notification, CancellationToken cancellationToken)
        {

            await _customerSellCreditRecordList.InsertAsync(notification.CustomerSellCreditRecordLists);

            // 

        }
    }
}
