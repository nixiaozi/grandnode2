using Leo.MonetaryCredit.Models;
using Leo.MonetaryCredit.Models.Events.UserAccount;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Infrastructure.Handler.UserAccount
{
    public class GetMonetaryUserNavigationHandler : IRequestHandler<GetMonetaryUserNavigation, MonetaryUserNavigationModel>
    {
        private readonly MonetaryCreditPaymentSettings _monetaryCreditPaymentSettings;

        public GetMonetaryUserNavigationHandler(MonetaryCreditPaymentSettings monetaryCreditPaymentSettings)
        {
            _monetaryCreditPaymentSettings = monetaryCreditPaymentSettings;
        }

        public async Task<MonetaryUserNavigationModel> Handle(GetMonetaryUserNavigation request, CancellationToken cancellationToken)
        {
            var model = new MonetaryUserNavigationModel {
                HideInfo = false,
                HideBalanceRecord = false,
                HideBanlanceRechangeOrder = false,
                HideMonetaryOrder = false,
                HideActivityCreditRecord = false,
                HideBuyCreditRecord = false,
                HideSellCreditRecord = false,
            };

            model.SelectedTab = (MonetaryUserNavigationEnum)request.SelectedTabId;

            return await Task.FromResult(model);
        }



    }
}
