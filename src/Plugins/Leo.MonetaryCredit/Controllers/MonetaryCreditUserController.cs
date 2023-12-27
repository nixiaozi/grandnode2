using Grand.Infrastructure;
using Grand.Infrastructure.Mapper;
using Grand.Web.Common.Controllers;
using Grand.Web.Common.Filters;
using Leo.MonetaryCredit.Domain;
using Leo.MonetaryCredit.Models.User;
using Leo.MonetaryCredit.Services;
using MediatR;
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
        private readonly IMediator _mediator;
        private readonly IMonetaryCreditService _monetaryCreditService;

        public MonetaryCreditUserController(MonetaryCreditPaymentSettings monetaryCreditPaymentSettings,
            IWorkContext workContext, IMediator mediator, IMonetaryCreditService monetaryCreditService)
        {
            _monetaryCreditPaymentSettings = monetaryCreditPaymentSettings;
            _workContext = workContext;
            _mediator = mediator;
            _monetaryCreditService = monetaryCreditService;
        }

        /// <summary>
        /// 首页数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [PublicStore(true)]
        public async Task<IActionResult> Default()
        {
            var data = await _monetaryCreditService.GetUserMonetaryCreditData(_workContext.CurrentCustomer.Id);

            var model = data.MapTo<CustomerBalanceData, MonetaryCreditUserInfoModel>();

            model.CustomerName = _workContext.CurrentCustomer.Username;


            return View(model);
        }

        /// <summary>
        /// 信用货币账户变动记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [PublicStore(true)]
        public async Task<IActionResult> BalanceRecord()
        {
            // 添加数据   —— 固定数据 和列表数据，以及相关的订单撤回功能

            return View();
        }

        /// <summary>
        /// 信用账户充值订单记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [PublicStore(true)]
        public async Task<IActionResult> BanlanceRechangeOrder()
        {
            // 添加数据   —— 固定数据 和列表数据，以及相关的订单撤回功能

            return View();
        }

        /// <summary>
        /// 信用货币信用兑换订单记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [PublicStore(true)]
        public async Task<IActionResult> MonetaryOrder()
        {
            // 添加数据   —— 固定数据 和列表数据，以及相关的订单撤回功能
            
            return View();
        }

        /// <summary>
        /// 购买积分变动记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [PublicStore(true)]
        public async Task<IActionResult> BuyCreditRecord()
        {
            // 添加数据   —— 固定数据 和列表数据，以及相关的订单撤回功能

            return View();
        }

        /// <summary>
        /// 销售积分变动记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [PublicStore(true)]
        public async Task<IActionResult> SellCreditRecord()
        {
            // 添加数据   —— 固定数据 和列表数据，以及相关的订单撤回功能

            return View();
        }

        /// <summary>
        /// 活动积分变动记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [PublicStore(true)]
        public async Task<IActionResult> ActivityCreditRecord()
        {
            // 添加数据   —— 固定数据 和列表数据，以及相关的订单撤回功能

            return View();
        }



    }
}
