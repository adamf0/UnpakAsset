using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Application.GetRepairAsset;
using UnpakAsset.Modules.RepairAsset.Domain.RepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Application.GetRepairAsset
{
    internal sealed class GetRepairAssetQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetRepairAssetQuery, RepairAssetResponse>
    {
        public async Task<Result<RepairAssetResponse>> Handle(GetRepairAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            //CAST(NULLIF(id_group, '') AS CHAR(36)) -> guid
            const string sql =
                $"""
             SELECT 
                 CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                 type AS Tipe,
                 pic as PIC,
                 id_group AS Grup,
                 id_sub_group AS SubGrup,
                 id_location AS Lokasi,
                 informasi AS Informasi
             FROM repair_asset
             WHERE id = @Id
             """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<RepairAssetResponse?>(sql, new { Id = request.RepairAssetId });
            if (result == null)
            {
                return Result.Failure<RepairAssetResponse>(RepairAssetErrors.NotFound(request.RepairAssetId));
            }

            return result;
        }
    }
}
