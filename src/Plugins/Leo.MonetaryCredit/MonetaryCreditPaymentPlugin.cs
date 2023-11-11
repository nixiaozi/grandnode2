using Grand.Business.Core.Extensions;
using Grand.Business.Core.Interfaces.Common.Configuration;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Business.Core.Interfaces.Common.Logging;
using Grand.Domain.Logging;
using Grand.Infrastructure.Plugins;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit
{
    public class MonetaryCreditPaymentPlugin : BasePlugin, IPlugin
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;
        private readonly ILanguageService _languageService;
        private readonly ISettingService _settingService;

        List<ActivityLogType> activityLogTypes = new List<ActivityLogType>
            {
                new ActivityLogType
                {
                    SystemKeyword = "AddRechange", // 
                    Enabled = true,
                    Name = "User Rechange"
                },
                new ActivityLogType
                {
                    SystemKeyword = "RecallRechange", // 
                    Enabled = true,
                    Name = "Recall User Rechange"
                },
                new ActivityLogType {
                    SystemKeyword = "UseRechange", // 
                    Enabled = true,
                    Name = "Use User Rechange"
                },
                new ActivityLogType {
                    SystemKeyword = "AddBuyCredit", // 
                    Enabled = true,
                    Name = "Add Buy Credit"
                },
                new ActivityLogType {
                    SystemKeyword = "RecallBuyCredit", // 
                    Enabled = true,
                    Name = "Recall Buy Credit"
                },
                new ActivityLogType {
                    SystemKeyword = "UseBuyCredit", // 
                    Enabled = true,
                    Name = "Use Buy Credit"
                },
                new ActivityLogType {
                    SystemKeyword = "AddSellCredit", // 
                    Enabled = true,
                    Name = "Add Sell Credit"
                },
                new ActivityLogType {
                    SystemKeyword = "RecallSellCredit", // 
                    Enabled = true,
                    Name = "Recall Sell Credit"
                },
                new ActivityLogType {
                    SystemKeyword = "UseSellCredit", // 
                    Enabled = true,
                    Name = "Use Sell Credit"
                },
                new ActivityLogType {
                    SystemKeyword = "AddActivityCredit", // 
                    Enabled = true,
                    Name = "Add Activity Credit"
                },
                new ActivityLogType {
                    SystemKeyword = "RecallActivityCredit", // 
                    Enabled = true,
                    Name = "Recall Activity Credit"
                },
                new ActivityLogType {
                    SystemKeyword = "UseActivityCredit", // 
                    Enabled = true,
                    Name = "Use Activity Credit"
                },
            };


#endregion

#region Ctor

public MonetaryCreditPaymentPlugin(
            ICustomerActivityService customerActivityService,
            ISettingService settingService,
            ILanguageService languageService,
            ITranslationService translationService)
        {
            _customerActivityService = customerActivityService;
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


            // 添加活动日志类型
            foreach(var item in activityLogTypes)
            {
                await _customerActivityService.InsertActivityType(item);
            }

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

            // 删除活动日志类型
            foreach(var item in activityLogTypes)
            {
                await _customerActivityService.DeleteActivityType(item);
            }

            await base.Uninstall();
        }

        #endregion

    }
}
