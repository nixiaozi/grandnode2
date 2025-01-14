﻿using Grand.Business.Core.Interfaces.Checkout.Payments;
using Grand.Business.Core.Interfaces.Cms;
using Grand.Infrastructure;
using Leo.MonetaryCredit;
using Leo.MonetaryCredit.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Payments.BrainTree
{
    public class StartupApplication : IStartupApplication
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPaymentProvider, MonetaryCreditPaymentProvider>();
            services.AddScoped<IWidgetProvider, MonetaryCreditPaymentWidgetProvider>();
            services.AddScoped<IWidgetProvider, MonetaryCreditUserAccountWidgetProvider>(); // 添加用户菜单

            // 自定义信用货币服务
            services.AddScoped<IMonetaryCreditService, MonetaryCreditService>();
        }

        public int Priority => 10;
        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {

        }
        public bool BeforeConfigure => false;

    }

}
