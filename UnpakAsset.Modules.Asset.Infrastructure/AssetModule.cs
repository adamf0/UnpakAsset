using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnpakAsset.Modules.Asset.Domain.Asset;
using UnpakAsset.Modules.Asset.Infrastructure.Database;
using UnpakAsset.Modules.Asset.Infrastructure.Asset;
using UnpakAsset.Modules.Asset.Presentation.Asset;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.Asset.Application.Abstractions.Data;

namespace UnpakAsset.Modules.Asset.Infrastructure
{
    public static class AssetModule
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            AssetEndpoints.MapEndpoints(app);
        }

        public static IServiceCollection AddAssetModule(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddInfrastructure(configuration);

            return services;
        }

        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string databaseConnectionString = configuration.GetConnectionString("Database")!;

            services.AddScoped<IDbConnectionFactory>(_ => new DbConnectionFactory(databaseConnectionString));

            services.AddDbContext<AssetDbContext>(optionsBuilder => optionsBuilder.UseMySQL(databaseConnectionString));

            services.AddScoped<IAssetRepository, AssetRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AssetDbContext>());
        }
    }
}
