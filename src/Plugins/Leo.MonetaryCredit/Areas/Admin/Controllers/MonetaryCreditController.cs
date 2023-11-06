using Grand.Business.Core.Interfaces.Common.Configuration;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Business.Core.Utilities.Common.Security;
using Grand.Web.Common.Controllers;
using Grand.Web.Common.Filters;
using Grand.Web.Common.Security.Authorization;
using Microsoft.AspNetCore.Mvc;
using Leo.MonetaryCredit.Models;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Areas.Admin.Controllers
{
    [AuthorizeAdmin]
    [Area("Admin")]
    [PermissionAuthorize(PermissionSystemName.PaymentMethods)]
    public class MonetaryCreditController : BasePaymentController
    {
        #region Fields

        private readonly ISettingService _settingService;
        private readonly ITranslationService _translationService;
        private readonly MonetaryCreditPaymentSettings _monetaryCreditPaymentSettings;

        #endregion

        #region Ctor

        public MonetaryCreditController(ISettingService settingService,
            ITranslationService translationService,
            MonetaryCreditPaymentSettings monetaryCreditPaymentSettings)
        {
            _settingService = settingService;
            _translationService = translationService;
            _monetaryCreditPaymentSettings = monetaryCreditPaymentSettings;
        }

        #endregion

        #region Methods

        public IActionResult Configure()
        {
            var model = new ConfigurationModel
            {
                LimitTotalRecharge = _monetaryCreditPaymentSettings.LimitTotalRecharge,
                CreditRate = _monetaryCreditPaymentSettings.CreditRate,
                DisplayOrder = _monetaryCreditPaymentSettings.DisplayOrder
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            //save settings
            _monetaryCreditPaymentSettings.LimitTotalRecharge = model.LimitTotalRecharge;
            _monetaryCreditPaymentSettings.CreditRate = model.CreditRate;
            _monetaryCreditPaymentSettings.DisplayOrder = model.DisplayOrder;

            await _settingService.SaveSetting(_monetaryCreditPaymentSettings);

            Success(_translationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        #endregion
    }
}