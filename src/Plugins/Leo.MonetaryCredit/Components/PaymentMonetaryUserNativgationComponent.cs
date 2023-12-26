using Grand.Infrastructure;
using Grand.Web.Common.Components;
using Leo.MonetaryCredit.Models.Events.UserAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Components
{
    [ViewComponent(Name = "PaymentMonetaryUserNativgation")]
    public class PaymentMonetaryUserNativgationComponent: BaseViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IWorkContext _workContext;

        public PaymentMonetaryUserNativgationComponent(IMediator mediator,
            IWorkContext workContext)
        {
            _mediator = mediator;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int selectedTabId = 0)
        {
            var model = await _mediator.Send(new GetMonetaryUserNavigation {
                Customer = _workContext.CurrentCustomer,
                Language = _workContext.WorkingLanguage,
                SelectedTabId = selectedTabId,
                Store = _workContext.CurrentStore,
                Vendor = _workContext.CurrentVendor
            });
            return View(model);
        }

    }
}
