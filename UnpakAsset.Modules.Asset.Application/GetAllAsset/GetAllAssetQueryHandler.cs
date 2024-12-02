using Dapper;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Asset.Domain.Asset;
using System.Data.Common;
using UnpakAsset.Modules.Asset.Application.GetAsset;

namespace UnpakAsset.Modules.Asset.Application.GetAllAsset
{
    internal sealed class GetAllAssetQueryHandler(IDbConnectionFactory _dbConnectionFactory) : IQueryHandler<GetAllAssetQuery, List<AssetResponse>>
    {
        public async Task<Result<List<AssetResponse>>> Handle(GetAllAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync();

            const string sql =
            """
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
            """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QueryAsync<AssetResponse>(sql);

            if (result == null || !result.Any())
            {
                return Result.Failure<List<AssetResponse>>(AssetErrors.EmptyData());
            }

            return Result.Success(result.ToList());
        }
    }
}
