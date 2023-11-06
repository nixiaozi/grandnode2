using Microsoft.AspNetCore.Mvc;

namespace Leo.MonetaryCredit.Components
{
    [ViewComponent(Name = "PaymentMonetaryCreditScripts")]
    public class PaymentMonetaryCreditScripts : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
