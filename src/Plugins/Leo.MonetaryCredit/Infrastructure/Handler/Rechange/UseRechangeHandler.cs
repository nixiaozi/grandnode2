using Grand.Domain.Data;
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
    public class UseRechangeHandler : INotificationHandler<UseRechangeEvent>
    {
        private readonly IRepository<CustomerBalanceRechangeOrder> _customerRechangeListRepository;

        public UseRechangeHandler(IRepository<CustomerBalanceRechangeOrder> customerRechangeListRepository)
        {
            _customerRechangeListRepository = customerRechangeListRepository;


        }


        public async Task Handle(UseRechangeEvent notification, CancellationToken cancellationToken)
        {
            CustomerBalanceRechangeOrder model = new CustomerBalanceRechangeOrder();

            await _customerRechangeListRepository.InsertAsync(model);

            // 

        }
    }
}
