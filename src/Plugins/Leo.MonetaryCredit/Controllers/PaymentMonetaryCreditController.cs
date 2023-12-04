using Grand.Business.Core.Interfaces.Checkout.Orders;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Domain.Orders;
using Grand.Infrastructure;
using Grand.Web.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Leo.MonetaryCredit.Models;
using Leo.MonetaryCredit.Validators;
using System.Net;
using Leo.MonetaryCredit;
using System.Threading.Tasks;
using System.Linq;
using System;
using Leo.MonetaryCredit.Services;

namespace Leo.MonetaryCredit.Controllers
{
    public class PaymentMonetaryCreditController : BasePaymentController
    {
        private readonly MonetaryCreditPaymentSettings _monetaryCreditPaymentSettings;
        private readonly IOrderCalculationService _orderTotalCalculationService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWorkContext _workContext;
        private readonly ITranslationService _translationService;
        private readonly IMonetaryCreditService _monetaryCreditService;

        public PaymentMonetaryCreditController(MonetaryCreditPaymentSettings monetaryCreditPaymentSettings,
            IOrderCalculationService orderTotalCalculationService,
            IShoppingCartService shoppingCartService,
            IWorkContext workContext,
            ITranslationService translationService,
            IMonetaryCreditService monetaryCreditService)
        {
            _monetaryCreditPaymentSettings = monetaryCreditPaymentSettings;
            _orderTotalCalculationService = orderTotalCalculationService;
            _shoppingCartService = shoppingCartService;
            _workContext = workContext;
            _translationService = translationService;

            _monetaryCreditService = monetaryCreditService;
        }

        public async Task<IActionResult> PaymentInfo()
        {
            var model = new PaymentInfoModel();

            var customer = _workContext.CurrentCustomer;

            var monetaryCredit = await _monetaryCreditService.GetUserMonetaryCreditData(customer.Id);

            model.YuE = monetaryCredit.CurrentBalanceRemain;

            var shoppingCarts = await _shoppingCartService.GetShoppingCart(_workContext.CurrentStore.Id, ShoppingCartType.ShoppingCart);



            //if (_monetaryCreditPaymentSettings.Use3DS)
            //{
            //    var cart = await _shoppingCartService.GetShoppingCart(_workContext.CurrentStore.Id, ShoppingCartType.ShoppingCart);

            //    if (!cart.Any())
            //        throw new Exception("Your cart is empty");

            //    //get settings
            //    var useSandBox = _monetaryCreditPaymentSettings.UseSandBox;
            //    var merchantId = _monetaryCreditPaymentSettings.MerchantId;
            //    var publicKey = _monetaryCreditPaymentSettings.PublicKey;
            //    var privateKey = _monetaryCreditPaymentSettings.PrivateKey;

            //    //var gateway = new BraintreeGateway {
            //    //    Environment = useSandBox ? Braintree.Environment.SANDBOX : Braintree.Environment.PRODUCTION,
            //    //    MerchantId = merchantId,
            //    //    PublicKey = publicKey,
            //    //    PrivateKey = privateKey
            //    //};

            //    //ViewBag.ClientToken = await gateway.ClientToken.GenerateAsync();
            //    //ViewBag.OrderTotal = (await _orderTotalCalculationService.GetShoppingCartTotal(cart)).shoppingCartTotal;

            //    return View("PaymentInfo_3DS", model);
            //}

            ////years
            //for (var i = 0; i < 15; i++)
            //{
            //    var year = Convert.ToString(DateTime.Now.Year + i);
            //    model.ExpireYears.Add(new SelectListItem {
            //        Text = year,
            //        Value = year
            //    });
            //}

            //months
            //for (var i = 1; i <= 12; i++)
            //{
            //    var text = i < 10 ? "0" + i : i.ToString();
            //    model.ExpireMonths.Add(new SelectListItem {
            //        Text = text,
            //        Value = i.ToString()
            //    });
            //}

            //set postback values (we cannot access "Form" with "GET" requests)
            //if (Request.Method == WebRequestMethods.Http.Get)
            //    return View("PaymentInfo", model);

            //var form = await HttpContext.Request.ReadFormAsync();

            //model.CardholderName = form["CardholderName"];
            //model.CardNumber = form["CardNumber"];
            //model.CardCode = form["CardCode"];

            //var selectedMonth = model.ExpireMonths
            //    .FirstOrDefault(x => x.Value.Equals(form["ExpireMonth"], StringComparison.InvariantCultureIgnoreCase));
            //if (selectedMonth != null)
            //    selectedMonth.Selected = true;
            //var selectedYear = model.ExpireYears
            //    .FirstOrDefault(x => x.Value.Equals(form["ExpireYear"], StringComparison.InvariantCultureIgnoreCase));
            //if (selectedYear != null)
            //    selectedYear.Selected = true;

            var validator = new PaymentInfoValidator(_monetaryCreditPaymentSettings, _translationService);
            var results = await validator.ValidateAsync(model);
            if (results.IsValid) return View("PaymentInfo", model);
            var query = from error in results.Errors
                select error.ErrorMessage;
            model.Errors = string.Join(", ", query);
            return View("PaymentInfo", model);
        }
    }
}