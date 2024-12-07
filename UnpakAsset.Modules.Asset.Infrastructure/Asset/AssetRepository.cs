using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.Asset.Domain.Asset;
using UnpakAsset.Modules.Asset.Infrastructure.Database;

namespace UnpakAsset.Modules.Asset.Infrastructure.Asset
{
    internal sealed class AssetRepository(AssetDbContext context) : IAssetRepository
    {
        public async Task<Domain.Asset.Asset> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.Asset.Asset location = await context.Asset.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);
            return location;
        }

        public async Task DeleteAsync(Domain.Asset.Asset location)
        {
            context.Asset.Remove(location);
        }

        public void Insert(Domain.Asset.Asset location)
        {
            context.Asset.Add(location);
        }
    }
}
