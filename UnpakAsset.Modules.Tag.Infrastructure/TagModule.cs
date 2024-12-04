using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Common.Infrastructure.Data;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Modules.Tag.Infrastructure.Database;
using UnpakAsset.Modules.Tag.Domain.Group;
using UnpakAsset.Modules.Tag.Infrastructure.Group;
using UnpakAsset.Modules.Tag.Presentation.Group;
using UnpakAsset.Modules.Tag.Domain.Location;
using UnpakAsset.Modules.Tag.Infrastructure.Location;
using UnpakAsset.Modules.Tag.Presentation.Location;

namespace UnpakTag.Modules.Tag.Infrastructure
{
    public static class TagModule
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            GroupEndpoints.MapEndpoints(app);
            LocationEndpoints.MapEndpoints(app);
        }

        public static IServiceCollection AddTagModule(
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

            services.AddDbContext<TagDbContext>(optionsBuilder => optionsBuilder.UseMySQL(databaseConnectionString));

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TagDbContext>());
        }
    }
}
