using Dapper;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Asset.Domain.Asset;
using System.Data.Common;

namespace UnpakAsset.Modules.Asset.Application.GetAsset
{
    internal sealed class GetAssetQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetAssetQuery, AssetResponse>
    {
        public async Task<Result<AssetResponse>> Handle(GetAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            //CAST(NULLIF(id_group, '') AS CHAR(36)) -> guid
            const string sql =
                $"""
             SELECT 
                 CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                 nama,
                 tanggal_terdaftar AS TanggalTerdaftar,
                 kondisi,
                 kode_aset AS KodeAset,
                 CAST(NULLIF(id_group, '') AS VARCHAR(36)) AS Grup,
                 CAST(NULLIF(id_sub_group, '') AS VARCHAR(36)) AS SubGrup,
                 CAST(NULLIF(id_location, '') AS VARCHAR(36)) AS Lokasi,
                 po,
                 harga_per_unit AS HargaPerUnit,
                 total_unit AS TotalUnit
             FROM asset
             WHERE id = @Id
             """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<AssetResponse?>(sql, new { Id = request.AssetId });
            if (result == null)
            {
                return Result.Failure<AssetResponse>(AssetErrors.NotFound(request.AssetId));
            }

            return result;
        }
    }
}
