using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Domain.AssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Application.GetAssignAsset
{
    internal sealed class GetAssignAssetQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetAssignAssetQuery, AssignAssetResponse>
    {
        public async Task<Result<AssignAssetResponse>> Handle(GetAssignAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            //CAST(NULLIF(id_group, '') AS CHAR(36)) -> guid
            const string sql =
                $"""
             SELECT 
                 CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                 nidn as Nidn,
                 nip AS Nip,
                 kode_fakultas as Fakultas,
                 kode_prodi AS Prodi,
                 kode_unit AS Unit,
                 id_asset_barcode AS Barcode 
             FROM assign_asset
             WHERE id = @Id
             """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<AssignAssetResponse?>(sql, new { Id = request.AssignAssetId });
            if (result == null)
            {
                return Result.Failure<AssignAssetResponse>(AssignAssetErrors.NotFound(request.AssignAssetId));
            }

            return result;
        }
    }
}
