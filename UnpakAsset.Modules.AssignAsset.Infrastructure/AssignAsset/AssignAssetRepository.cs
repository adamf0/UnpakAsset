using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.AssignAsset.Domain.AssignAsset;
using UnpakAsset.Modules.AssignAsset.Infrastructure.Database;

namespace UnpakAsset.Modules.AssignAsset.Infrastructure.AssignAsset
{
    internal sealed class AssignAssetRepository(AssignAssetDbContext context) : IAssignAssetRepository
    {
        public async Task<Domain.AssignAsset.AssignAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.AssignAsset.AssignAsset AssignAsset = await context.AssignAsset.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);

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

            return AssignAsset;
        }

        public async Task DeleteAsync(Domain.AssignAsset.AssignAsset AssignAsset)
        {
            context.AssignAsset.Remove(AssignAsset);
        }

        public void Insert(Domain.AssignAsset.AssignAsset AssignAsset)
        {
            context.AssignAsset.Add(AssignAsset);
        }
    }
}
