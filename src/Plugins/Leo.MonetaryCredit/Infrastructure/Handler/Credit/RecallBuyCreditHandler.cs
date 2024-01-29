using Grand.Domain.Data;
using Grand.Infrastructure.Events;
using Leo.MonetaryCredit.Domain;
using Leo.MonetaryCredit.Models.Events;
using Leo.MonetaryCredit.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Infrastructure.Handler
{
    public class RecallBuyCreditHandler : INotificationHandler<RecallRechangeEvent>
    {
        private readonly IMonetaryCreditService _monetaryCreditService;

        public RecallBuyCreditHandler(IMonetaryCreditService monetaryCreditService)
        {
            monetaryCreditService = _monetaryCreditService;
        }

        public Task Handle(RecallRechangeEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
