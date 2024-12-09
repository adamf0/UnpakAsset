using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset;
using UnpakAsset.Modules.PhysicalAsset.Infrastructure.Database;

namespace UnpakAsset.Modules.PhysicalAsset.Infrastructure.PhysicalAsset
{
    internal sealed class PhysicalAssetRepository(PhysicalAssetDbContext context) : IPhysicalAssetRepository
    {
        public async Task<Domain.PhysicalAsset.PhysicalAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.PhysicalAsset.PhysicalAsset PhysicalAsset = await context.PhysicalAsset.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);

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

            return PhysicalAsset;
        }

        public async Task DeleteAsync(Domain.PhysicalAsset.PhysicalAsset PhysicalAsset)
        {
            context.PhysicalAsset.Remove(PhysicalAsset);
        }

        public void Insert(Domain.PhysicalAsset.PhysicalAsset PhysicalAsset)
        {
            context.PhysicalAsset.Add(PhysicalAsset);
        }
    }
}
