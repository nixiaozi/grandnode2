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
    public class RecallRechangeHandler : INotificationHandler<RecallRechangeEvent>
    {
        private readonly IRepository<CustomerBalanceRechangeList> _customerRechangeListRepository;

        public RecallRechangeHandler(IRepository<CustomerBalanceRechangeList> customerRechangeListRepository)
        {
            _customerRechangeListRepository = customerRechangeListRepository;
        }

        public Task Handle(RecallRechangeEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
