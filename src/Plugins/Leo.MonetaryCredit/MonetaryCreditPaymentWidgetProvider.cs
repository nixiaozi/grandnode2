using Grand.Business.Core.Interfaces.Cms;
using Grand.Business.Core.Interfaces.Common.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit
{
    public class MonetaryCreditPaymentWidgetProvider : IWidgetProvider
    {
        private readonly ITranslationService _translationService;
        private readonly MonetaryCreditPaymentSettings _monetaryCreditPaymentSettings;

        public MonetaryCreditPaymentWidgetProvider(ITranslationService translationService, MonetaryCreditPaymentSettings monetaryCreditPaymentSettings)
        {
            _translationService = translationService;
            _monetaryCreditPaymentSettings = monetaryCreditPaymentSettings;
        }

        public string ConfigurationUrl => MonetaryCreditDefaults.ConfigurationUrl;

        public string SystemName => MonetaryCreditDefaults.ProviderSystemName;

        public string FriendlyName => _translationService.GetResource(MonetaryCreditDefaults.FriendlyName);

        public int Priority => _monetaryCreditPaymentSettings.DisplayOrder;

        public IList<string> LimitedToStores => new List<string>();

        public IList<string> LimitedToGroups => new List<string>();

        public async Task<IList<string>> GetWidgetZones()
        {
            return await Task.FromResult(new[] { "checkout_payment_info_top" });
        }

        public Task<string> GetPublicViewComponentName(string widgetZone)
        {
            return Task.FromResult("PaymentMonetaryCreditScripts");
        }
    }
}
