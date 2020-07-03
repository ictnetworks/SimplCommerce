using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Catalog.Data;
using SimplCommerce.Module.Core;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Catalog;
using SimplCommerce.Module.Core.Services;
using MediatR;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Catalog.Events;

namespace ICT.Module.ImportExport
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection ictserviceCollection)
        {
            ictserviceCollection.AddTransient<IEntityService, EntityService>();
            ictserviceCollection.AddTransient<IMediaService, MediaService>();
            ictserviceCollection.AddTransient<IThemeService, ThemeService>();
            ictserviceCollection.AddTransient<IWidgetInstanceService, WidgetInstanceService>();
            ictserviceCollection.AddScoped<IWorkContext, WorkContext>();
            ictserviceCollection.AddScoped<ISmsSender, SmsSender>();
            ictserviceCollection.AddSingleton<SettingDefinitionProvider>();
            ictserviceCollection.AddScoped<ISettingService, SettingService>();
            ictserviceCollection.AddScoped<ICurrencyService, CurrencyService>();
            ictserviceCollection.AddTransient<IProductTemplateProductAttributeRepository, ProductTemplateProductAttributeRepository>();
            ictserviceCollection.AddTransient<INotificationHandler<ReviewSummaryChanged>, ReviewSummaryChangedHandler>();
            ictserviceCollection.AddTransient<IBrandService, BrandService>();
            ictserviceCollection.AddTransient<ICategoryService, CategoryService>();
            ictserviceCollection.AddTransient<IProductPricingService, ProductPricingService>();
            ictserviceCollection.AddTransient<IProductService, ProductService>();

            GlobalConfiguration.RegisterAngularModule("simplAdmin.core");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
