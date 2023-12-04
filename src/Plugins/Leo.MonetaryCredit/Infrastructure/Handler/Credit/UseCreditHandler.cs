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
    public class UseCreditHandler : INotificationHandler<UseRechangeEvent>
    {
        private readonly IRepository<CustomerBalanceRechangeList> _customerRechangeListRepository;

        public UseCreditHandler(IRepository<CustomerBalanceRechangeList> customerRechangeListRepository)
        {
            _customerRechangeListRepository = customerRechangeListRepository;


        }


        public async Task Handle(UseRechangeEvent notification, CancellationToken cancellationToken)
        {
            CustomerBalanceRechangeList model = new CustomerBalanceRechangeList();

            await _customerRechangeListRepository.InsertAsync(model);

            // 

        }
    }
}
