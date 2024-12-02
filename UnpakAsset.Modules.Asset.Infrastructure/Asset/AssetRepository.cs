using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.Asset.Domain.Asset;
using UnpakAsset.Modules.Asset.Infrastructure.Database;

namespace UnpakAsset.Modules.Asset.Infrastructure.Asset
{
    internal sealed class AssetRepository(AssetDbContext context) : IAssetRepository
    {
        public async Task<Domain.Asset.Asset> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.Asset.Asset asset = await context.Asset.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);
            
            /*Domain.Asset.Asset asset = await context.Asset
                .FromSqlRaw(
                @"
                SELECT 
                    CAST(NULLIF(id, '') AS CHAR(36)) AS Id,
                    nama,
                    tanggal_terdaftar,
                    kondisi,
                    kode_aset,
                    CAST(NULLIF(id_group, '') AS CHAR(36)) AS id_group,
                    CAST(NULLIF(id_sub_group, '') AS CHAR(36)) AS id_sub_group,
                    CAST(NULLIF(id_location, '') AS CHAR(36)) AS id_location,
                    po,
                    harga_per_unit,
                    total_unit
                FROM asset
                WHERE CAST(NULLIF(id, '') AS CHAR(36)) = {0}
                ", [Id.ToString()])
                .SingleOrDefaultAsync(cancellationToken);*/

            return asset;
        }

        public async Task DeleteAsync(Domain.Asset.Asset aset)
        {
            context.Asset.Remove(aset);
        }

        public void Insert(Domain.Asset.Asset asset)
        {
            context.Asset.Add(asset);
        }
    }
}
