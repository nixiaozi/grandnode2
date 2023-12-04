using Grand.Business.Core.Interfaces.Cms;
using Grand.Business.Core.Interfaces.Common.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit
{
    public class MonetaryCreditUserAccountWidgetProvider : IWidgetProvider
    {
        private readonly ITranslationService _translationService;
        private readonly MonetaryCreditPaymentSettings _monetaryCreditPaymentSettings;

        public MonetaryCreditUserAccountWidgetProvider(ITranslationService translationService, MonetaryCreditPaymentSettings monetaryCreditPaymentSettings)
        {
            _translationService = translationService;
            _monetaryCreditPaymentSettings = monetaryCreditPaymentSettings;
        }

        public string ConfigurationUrl => MonetaryCreditDefaults.ConfigurationUrl;

        public string SystemName => MonetaryCreditDefaults.UserAccountProviderSystemName;

        public string FriendlyName => _translationService.GetResource(MonetaryCreditDefaults.UserAccountFriendlyName);

        public int Priority => _monetaryCreditPaymentSettings.DisplayOrder;

        public IList<string> LimitedToStores => new List<string>();

        public IList<string> LimitedToGroups => new List<string>();

        public async Task<IList<string>> GetWidgetZones()
        {
            return await Task.FromResult(new[] { "account_navigation_after" });
        }

        public Task<string> GetPublicViewComponentName(string widgetZone)
        {
            return Task.FromResult("PaymentMonetaryUserMenu");
        }
    }
}
