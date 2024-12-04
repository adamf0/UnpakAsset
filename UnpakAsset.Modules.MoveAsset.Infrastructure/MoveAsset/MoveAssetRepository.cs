using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.MoveAsset.Domain.MoveAsset;
using UnpakAsset.Modules.MoveAsset.Infrastructure.Database;

namespace UnpakAsset.Modules.MoveAsset.Infrastructure.MoveAsset
{
    internal sealed class MoveAssetRepository(MoveAssetDbContext context) : IMoveAssetRepository
    {
        public async Task<Domain.MoveAsset.MoveAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.MoveAsset.MoveAsset MoveAsset = await context.MoveAsset.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);

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

            return MoveAsset;
        }

        public async Task DeleteAsync(Domain.MoveAsset.MoveAsset MoveAsset)
        {
            context.MoveAsset.Remove(MoveAsset);
        }

        public void Insert(Domain.MoveAsset.MoveAsset MoveAsset)
        {
            context.MoveAsset.Add(MoveAsset);
        }
    }
}
