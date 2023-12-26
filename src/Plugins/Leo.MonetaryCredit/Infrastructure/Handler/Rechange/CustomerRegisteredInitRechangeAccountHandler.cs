using Grand.Business.Checkout.Services.Orders;
using Grand.Business.Core.Events.Customers;
using Grand.Business.Core.Interfaces.Checkout.Orders;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Domain.Customers;
using Grand.Domain.Data;
using Grand.Domain.Orders;
using Grand.Infrastructure.Extensions;
using Leo.MonetaryCredit.Domain;
using Leo.MonetaryCredit.Services;
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
        //private readonly IRepository<CustomerBalanceData> _customerCreditDataRepository;
        private readonly IMediator _mediator;
        private readonly IMonetaryCreditService _monetaryCreditService;


        public CustomerRegisteredInitRechangeAccountHandler(
            ITranslationService translationService,
            //IRepository<CustomerBalanceData> customerCreditDataRepository,
            IMediator mediator,
            IMonetaryCreditService monetaryCreditService
            )
        {
            _translationService = translationService;
           // _customerCreditDataRepository = customerCreditDataRepository;
            _mediator = mediator;
            _monetaryCreditService = monetaryCreditService;
        }

        public async Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
        {
           await _monetaryCreditService.GetUserMonetaryCreditData(notification.Customer.Id);

        }


    }
}
