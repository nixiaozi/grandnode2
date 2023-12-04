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
        private readonly IRepository<CustomerBalanceRechangeList> _customerRechangeListRepository;

        public RecallActivityCreditHandler(IRepository<CustomerBalanceRechangeList> customerRechangeListRepository)
        {
            _customerRechangeListRepository = customerRechangeListRepository;


        }


        public async Task Handle(RecallActivityCreditEvent notification, CancellationToken cancellationToken)
        {
            CustomerBalanceRechangeList model = new CustomerBalanceRechangeList();

            await _customerRechangeListRepository.InsertAsync(model);

            // 

        }
    }
}
