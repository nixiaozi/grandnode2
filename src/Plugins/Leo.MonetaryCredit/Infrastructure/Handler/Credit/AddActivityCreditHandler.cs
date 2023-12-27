﻿using Grand.Domain.Data;
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
    public class AddActivityCreditHandler : INotificationHandler<AddActivityCreditEvent>
    {
        private readonly IRepository<CustomerBalanceRechangeOrder> _customerRechangeListRepository;

        public AddActivityCreditHandler(IRepository<CustomerBalanceRechangeOrder> customerRechangeListRepository)
        {
            _customerRechangeListRepository = customerRechangeListRepository;


        }


        public async Task Handle(AddActivityCreditEvent notification, CancellationToken cancellationToken)
        {
            CustomerBalanceRechangeOrder model = new CustomerBalanceRechangeOrder();

            await _customerRechangeListRepository.InsertAsync(model);

            // 

        }
    }
}
