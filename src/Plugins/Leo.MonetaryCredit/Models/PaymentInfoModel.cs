using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Leo.MonetaryCredit.Models
{
    public class PaymentInfoModel : BaseModel
    {
        public PaymentInfoModel()
        {
            
        }

        [GrandResourceDisplayName("Payment.YuE")]
        public decimal YuE { get; set; }



        public string Errors { get; set; }

    }
}