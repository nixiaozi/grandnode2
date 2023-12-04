using Grand.Business.Checkout.Services.Orders;
using Grand.Business.Core.Events.Customers;
using Grand.Business.Core.Interfaces.Checkout.Orders;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Domain.Customers;
using Grand.Domain.Data;
using Grand.Domain.Orders;
using Grand.Infrastructure.Extensions;
using Leo.MonetaryCredit.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Infrastructure.Handler.Rechange
{
    public class CustomerRegisteredInitRechangeAccountHandler : INotificationHandler<CustomerRegisteredEvent>
    {

        private readonly ITranslationService _translationService;
        private readonly IRepository<CustomerBalanceData> _customerCreditDataRepository;
        private readonly IMediator _mediator;


        public CustomerRegisteredInitRechangeAccountHandler(
            ITranslationService translationService,
            IRepository<CustomerBalanceData> customerCreditDataRepository,
            IMediator mediator
            )
        {
            _translationService = translationService;
            _customerCreditDataRepository = customerCreditDataRepository;
            _mediator = mediator;
        }

        public async Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var data = await _customerCreditDataRepository.GetByIdAsync(notification.Customer.Id);

            if ( data == null )
            {
                data = new CustomerBalanceData {
                    ActionCreditRemain = 0,
                    TotalUsedActionCredit = 0,
                    BuyCreditRemain = 0,
                    CurrentBalanceRemain = 0,
                    TotalRechangeByCredit = 0,
                    TotalRechangeByThird = 0,
                    CustomerID = notification.Customer.CustomerGuid,
                    SellCreditRemain = 0,
                    TotalUsedSellCredit = 0,
                    UserCreditScore = 0,
                    TotalUsedBuyCredit = 0,
                    CreateDate = DateTime.Now,
                };

                await _customerCreditDataRepository.InsertAsync(data);

                //event notification
                await _mediator.EntityInserted(data);

            }


        }


    }
}
