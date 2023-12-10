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

        }
        public int Priority => 0;

    }
}
