using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Infrastructure.Data;
using UnpakAsset.Modules.MoveAsset.Domain.MoveAsset;
using UnpakAsset.Modules.MoveAsset.Infrastructure.MoveAsset;
using UnpakAsset.Modules.MoveAsset.Infrastructure.Database;
using UnpakAsset.Modules.MoveAsset.Presentation.MoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Infrastructure
{
    public static class MoveAssetModule
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            MoveAssetEndpoints.MapEndpoints(app);
        }

        public static IServiceCollection AddMoveAssetModule(
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

            services.AddDbContext<MoveAssetDbContext>(optionsBuilder => optionsBuilder.UseMySQL(databaseConnectionString));

            services.AddScoped<IMoveAssetRepository, MoveAssetRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MoveAssetDbContext>());
        }
    }
}
