using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset;
using UnpakAsset.Modules.DisposalAsset.Infrastructure.Database;

namespace UnpakAsset.Modules.DisposalAsset.Infrastructure.DisposalAsset
{
    internal sealed class DisposalAssetRepository(DisposalAssetDbContext context) : IDisposalAssetRepository
    {
        public async Task<Domain.DisposalAsset.DisposalAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.DisposalAsset.DisposalAsset DisposalAsset = await context.DisposalAsset.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);

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

            return DisposalAsset;
        }

        public async Task DeleteAsync(Domain.DisposalAsset.DisposalAsset DisposalAsset)
        {
            context.DisposalAsset.Remove(DisposalAsset);
        }

        public void Insert(Domain.DisposalAsset.DisposalAsset DisposalAsset)
        {
            context.DisposalAsset.Add(DisposalAsset);
        }
    }
}
