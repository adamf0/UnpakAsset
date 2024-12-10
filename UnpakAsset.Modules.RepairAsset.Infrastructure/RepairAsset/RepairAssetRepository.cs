using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.RepairAsset.Domain.RepairAsset;
using UnpakAsset.Modules.RepairAsset.Infrastructure.Database;

namespace UnpakAsset.Modules.RepairAsset.Infrastructure.RepairAsset
{
    internal sealed class RepairAssetRepository(RepairAssetDbContext context) : IRepairAssetRepository
    {
        public async Task<Domain.RepairAsset.RepairAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.RepairAsset.RepairAsset RepairAsset = await context.RepairAsset.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);

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

            return RepairAsset;
        }

        public async Task DeleteAsync(Domain.RepairAsset.RepairAsset RepairAsset)
        {
            context.RepairAsset.Remove(RepairAsset);
        }

        public void Insert(Domain.RepairAsset.RepairAsset RepairAsset)
        {
            context.RepairAsset.Add(RepairAsset);
        }
    }
}
