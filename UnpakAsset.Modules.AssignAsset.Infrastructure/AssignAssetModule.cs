using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnpakAsset.Modules.AssignAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Infrastructure.Data;
using UnpakAsset.Modules.AssignAsset.Domain.AssignAsset;
using UnpakAsset.Modules.AssignAsset.Infrastructure.AssignAsset;
using UnpakAsset.Modules.AssignAsset.Infrastructure.Database;
using UnpakAsset.Modules.AssignAsset.Presentation.AssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Infrastructure
{
    public static class AssignAssetModule
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            AssignAssetEndpoints.MapEndpoints(app);
        }

        public static IServiceCollection AddAssignAssetModule(
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

            services.AddDbContext<AssignAssetDbContext>(optionsBuilder => optionsBuilder.UseMySQL(databaseConnectionString));

            services.AddScoped<IAssignAssetRepository, AssignAssetRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AssignAssetDbContext>());
        }
    }
}
