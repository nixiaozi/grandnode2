using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Components
{
    [ViewComponent(Name = "PaymentMonetaryUserMenu")]
    public class PaymentMonetaryUserMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
