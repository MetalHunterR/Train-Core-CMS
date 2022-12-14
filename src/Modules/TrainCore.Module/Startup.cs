using System;
using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.GraphQL.Queries;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using TrainCore.Module.Drivers;
using TrainCore.Module.Handlers;
using TrainCore.Module.Indexes;
using TrainCore.Module.Migrations;
using TrainCore.Module.Models;
using YesSql.Indexes;

namespace TrainCore.Module
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<LayoutPart>()
                .UseDisplayDriver<LayoutPartDisplayDriver>()
                .AddHandler<LayoutPartHandler>();

            services.AddContentPart<CoachPart>()
                .UseDisplayDriver<CoachPartDisplayDriver>()
                .AddHandler<CoachPartHandler>();

            services.AddContentPart<LocomotivePart>()
                .UseDisplayDriver<LocomotivePartDisplayDriver>()
                .AddHandler<LocomotivePartHandler>();

            services.AddScoped<IDataMigration, LayoutPartMigrations>();
            services.AddScoped<IDataMigration, CoachePartMigrations>();
            services.AddScoped<IDataMigration, LocomotivePartMigrations>();

            services.AddSingleton<IIndexProvider, BasicTrainIndexProvider>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "TrainCore.Module",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
