using Grand.Business.Core.Extensions;
using Grand.Business.Core.Interfaces.Common.Configuration;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Infrastructure.Plugins;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit
{
    public class MonetaryCreditPaymentPlugin : BasePlugin, IPlugin
    {
        #region Fields

        private readonly ITranslationService _translationService;
        private readonly ILanguageService _languageService;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public MonetaryCreditPaymentPlugin(
            ISettingService settingService,
            ILanguageService languageService,
            ITranslationService translationService)
        {
            _settingService = settingService;
            _translationService = translationService;
            _languageService = languageService;
        }

        #endregion

        #region Methods


        public override string ConfigurationUrl()
        {
            return MonetaryCreditDefaults.ConfigurationUrl;
        }

        public override async Task Install()
        {
            //settings
            var settings = new MonetaryCreditPaymentSettings
            {
                LimitTotalRecharge = 1000000,
                CreditRate = (decimal)0.82d,
            };
            await _settingService.SaveSetting(settings);

            //locales
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Leo.MonetaryCredit.FriendlyName", "MonetaryCredit payment");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.Use3DS", "Use the 3D secure");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.Use3DS.Hint", "Check to enable the 3D secure integration");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.UseSandbox", "Use Sandbox");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.UseSandbox.Hint", "Check to enable Sandbox (testing environment).");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.MerchantId", "Merchant ID");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.MerchantId.Hint", "Enter Merchant ID");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.PublicKey", "Public Key");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.PublicKey.Hint", "Enter Public key");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.PrivateKey", "Private Key");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.PrivateKey.Hint", "Enter Private key");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.AdditionalFee", "Additional fee");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.AdditionalFee.Hint", "Enter additional fee to charge your customers.");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.AdditionalFeePercentage", "Additional fee. Use percentage");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.DisplayOrder", "Display order");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.AdditionalFeePercentage.Hint", "Determines whether to apply a percentage additional fee to the order total. If not enabled, a fixed value is used.");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.PaymentMethodDescription", "Pay by credit / debit card");

            
            await base.Install();
        }

        public override async Task Uninstall()
        {
            //settings
            await _settingService.DeleteSetting<MonetaryCreditPaymentSettings>();

            //locales
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Leo.MonetaryCredit.FriendlyName");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.UseSandbox");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.UseSandbox.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.MerchantId");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.MerchantId.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.PublicKey");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.PublicKey.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.PrivateKey");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.PrivateKey.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.AdditionalFee");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.AdditionalFee.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.AdditionalFeePercentage");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.Fields.AdditionalFeePercentage.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Plugins.Leo.MonetaryCredit.PaymentMethodDescription");

            await base.Uninstall();
        }

        #endregion

    }
}
