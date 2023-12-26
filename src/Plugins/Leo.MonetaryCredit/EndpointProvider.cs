using Grand.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Leo.MonetaryCredit
{
    public class EndpointProvider : IEndpointProvider
    {
        public void RegisterEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute("Plugin.PaymentMonetaryCredit",
                 "Plugins/PaymentMonetaryCredit/PaymentInfo",
                 new { controller = "PaymentMonetaryCredit", action = "PaymentInfo", area = "" }
            );

            endpointRouteBuilder.MapControllerRoute("Plugin.UserMonetaryCreditInfo",
                 "Plugins/MonetaryCreditUser/Default",
                 new { controller = "MonetaryCreditUser", action = "Default", area = "" }
            );


            endpointRouteBuilder.MapControllerRoute("Plugin.UserMonetaryCredit.MainInfo",
                 "Plugins/MonetaryCreditUser/Default",
                 new { controller = "MonetaryCreditUser", action = "Default", area = "" }
            );

            endpointRouteBuilder.MapControllerRoute("Plugin.UserMonetaryCredit.BalanceRecord",
                 "Plugins/MonetaryCreditUser/BalanceRecord",
                 new { controller = "MonetaryCreditUser", action = "BalanceRecord", area = "" }
            );

            endpointRouteBuilder.MapControllerRoute("Plugin.UserMonetaryCredit.BanlanceRechangeOrder",
                 "Plugins/MonetaryCreditUser/BanlanceRechangeOrder",
                 new { controller = "MonetaryCreditUser", action = "BanlanceRechangeOrder", area = "" }
            );

            endpointRouteBuilder.MapControllerRoute("Plugin.UserMonetaryCredit.MonetaryOrder",
                 "Plugins/MonetaryCreditUser/MonetaryOrder",
                 new { controller = "MonetaryCreditUser", action = "MonetaryOrder", area = "" }
            );

            endpointRouteBuilder.MapControllerRoute("Plugin.UserMonetaryCredit.BuyCreditRecord",
                 "Plugins/MonetaryCreditUser/BuyCreditRecord",
                 new { controller = "MonetaryCreditUser", action = "BuyCreditRecord", area = "" }
            );

            endpointRouteBuilder.MapControllerRoute("Plugin.UserMonetaryCredit.SellCreditRecord",
                 "Plugins/MonetaryCreditUser/SellCreditRecord",
                 new { controller = "MonetaryCreditUser", action = "SellCreditRecord", area = "" }
            );

            endpointRouteBuilder.MapControllerRoute("Plugin.UserMonetaryCredit.ActivityCreditRecord",
                 "Plugins/MonetaryCreditUser/ActivityCreditRecord",
                 new { controller = "MonetaryCreditUser", action = "ActivityCreditRecord", area = "" }
            );

        }
        public int Priority => 0;

    }
}
