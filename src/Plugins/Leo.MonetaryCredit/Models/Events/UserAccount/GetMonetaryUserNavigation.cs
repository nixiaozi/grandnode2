using Amazon.Runtime.Internal;
using Grand.Domain.Customers;
using Grand.Domain.Localization;
using Grand.Domain.Stores;
using Grand.Domain.Vendors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.Events.UserAccount
{
    public class GetMonetaryUserNavigation : IRequest<MonetaryUserNavigationModel>
    {
        public int SelectedTabId { get; set; }
        public Customer Customer { get; set; }
        public Language Language { get; set; }
        public Store Store { get; set; }
        public Vendor Vendor { get; set; }
    }
}
