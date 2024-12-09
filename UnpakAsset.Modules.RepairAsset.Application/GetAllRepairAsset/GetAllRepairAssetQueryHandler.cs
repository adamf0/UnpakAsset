using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Application.GetRepairAsset;
using UnpakAsset.Modules.RepairAsset.Application.GetRepairAsset;
using UnpakAsset.Modules.RepairAsset.Domain.RepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Application.GetAllRepairAsset
{
    internal sealed class GetAllRepairAssetQueryHandler(IDbConnectionFactory _dbConnectionFactory) : IQueryHandler<GetAllRepairAssetQuery, List<RepairAssetResponse>>
    {
        public async Task<Result<List<RepairAssetResponse>>> Handle(GetAllRepairAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync();

            const string sql =
            """
            SELECT 
                CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                type AS Tipe,
                pic as PIC,
                id_group AS Grup,
                id_sub_group AS SubGrup,
                id_location AS Lokasi,
                informasi AS Informasi
            FROM repair_asset
            """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QueryAsync<RepairAssetResponse>(sql);

            if (result == null || !result.Any())
            {
                return Result.Failure<List<RepairAssetResponse>>(RepairAssetErrors.EmptyData());
            }

            return Result.Success(result.ToList());
        }
    }
}
