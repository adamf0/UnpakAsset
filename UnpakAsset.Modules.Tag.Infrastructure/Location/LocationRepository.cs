using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.Tag.Infrastructure.Database;
using UnpakAsset.Modules.Tag.Domain.Location;

namespace UnpakAsset.Modules.Tag.Infrastructure.Location
{
    internal sealed class LocationRepository(TagDbContext context) : ILocationRepository
    {
        public async Task<Domain.Location.Location> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.Location.Location location = await context.Location.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);
            return location;
        }

        public async Task DeleteAsync(Domain.Location.Location location)
        {
            context.Location.Remove(location);
        }

        public void Insert(Domain.Location.Location location)
        {
            context.Location.Add(location);
        }
    }
}
