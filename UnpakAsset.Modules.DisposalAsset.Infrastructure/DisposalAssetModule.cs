using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnpakAsset.Modules.DisposalAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Infrastructure.Data;
using UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset;
using UnpakAsset.Modules.DisposalAsset.Infrastructure.DisposalAsset;
using UnpakAsset.Modules.DisposalAsset.Infrastructure.Database;
using UnpakAsset.Modules.DisposalAsset.Presentation.DisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Infrastructure
{
    public static class DisposalAssetModule
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            DisposalAssetEndpoints.MapEndpoints(app);
        }

        public static IServiceCollection AddDisposalAssetModule(
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

            services.AddDbContext<DisposalAssetDbContext>(optionsBuilder => optionsBuilder.UseMySQL(databaseConnectionString));

            services.AddScoped<IDisposalAssetRepository, DisposalAssetRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<DisposalAssetDbContext>());
        }
    }
}
