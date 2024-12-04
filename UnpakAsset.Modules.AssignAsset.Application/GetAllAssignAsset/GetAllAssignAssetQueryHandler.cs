using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Application.GetAssignAsset;
using UnpakAsset.Modules.AssignAsset.Domain.AssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Application.GetAllAssignAsset
{
    internal sealed class GetAllAssignAssetQueryHandler(IDbConnectionFactory _dbConnectionFactory) : IQueryHandler<GetAllAssignAssetQuery, List<AssignAssetResponse>>
    {
        public async Task<Result<List<AssignAssetResponse>>> Handle(GetAllAssignAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync();

            const string sql =
            """
            SELECT 
                CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                nidn as Nidn,
                nip AS Nip,
                kode_fakultas as Fakultas,
                kode_prodi AS Prodi,
                kode_unit AS Unit,
                id_asset_barcode AS Barcode 
            FROM assign_asset
            """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QueryAsync<AssignAssetResponse>(sql);

            if (result == null || !result.Any())
            {
                return Result.Failure<List<AssignAssetResponse>>(AssignAssetErrors.EmptyData());
            }

            return Result.Success(result.ToList());
        }
    }
}
