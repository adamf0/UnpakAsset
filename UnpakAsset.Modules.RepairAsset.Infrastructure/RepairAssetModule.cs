using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnpakAsset.Modules.RepairAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Infrastructure.Data;
using UnpakAsset.Modules.RepairAsset.Domain.RepairAsset;
using UnpakAsset.Modules.RepairAsset.Infrastructure.RepairAsset;
using UnpakAsset.Modules.RepairAsset.Infrastructure.Database;
using UnpakAsset.Modules.RepairAsset.Presentation.RepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Infrastructure
{
    public static class RepairAssetModule
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            RepairAssetEndpoints.MapEndpoints(app);
        }

        public static IServiceCollection AddRepairAssetModule(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddInfrastructure(configuration);

            return services;
        }

        /*public static IServiceCollection AddUserModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
            });

            //services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

            services.AddInfrastructure(configuration);

            return services;
        }*/

        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string databaseConnectionString = configuration.GetConnectionString("Database")!;

            //services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IDbConnectionFactory>(_ => new DbConnectionFactory(databaseConnectionString));

            services.AddDbContext<RepairAssetDbContext>(optionsBuilder => optionsBuilder.UseMySQL(databaseConnectionString));

            services.AddScoped<IRepairAssetRepository, RepairAssetRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<RepairAssetDbContext>());
        }
    }
}
