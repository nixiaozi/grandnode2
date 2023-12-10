using Grand.Infrastructure;
using Grand.Web.Common.Controllers;
using Grand.Web.Common.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Controllers
{
    [DenySystemAccount]
    public class MonetaryCreditUserController:BasePluginController
    {
        private readonly MonetaryCreditPaymentSettings _monetaryCreditPaymentSettings; 
        private readonly IWorkContext _workContext;

        public MonetaryCreditUserController(MonetaryCreditPaymentSettings monetaryCreditPaymentSettings,
            IWorkContext workContext) 
        {
            _monetaryCreditPaymentSettings = monetaryCreditPaymentSettings;
            _workContext = workContext;
        }

        [HttpGet]
        [PublicStore(true)]
        public async Task<IActionResult> Default()
        {
            // 添加数据   —— 固定数据 和列表数据，以及相关的订单撤回功能

            return View();
        }


    }
}
