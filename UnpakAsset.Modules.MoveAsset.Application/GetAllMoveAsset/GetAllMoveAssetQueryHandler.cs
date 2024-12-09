using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.MoveAsset.Application.GetMoveAsset;
using UnpakAsset.Modules.MoveAsset.Domain.MoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Application.GetAllMoveAsset
{
    internal sealed class GetAllMoveAssetQueryHandler(IDbConnectionFactory _dbConnectionFactory) : IQueryHandler<GetAllMoveAssetQuery, List<MoveAssetResponse>>
    {
        public async Task<Result<List<MoveAssetResponse>>> Handle(GetAllMoveAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync();

            const string sql =
            """
            SELECT 
                CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                id_ticket as Tiket,
                type AS Tipe,
                pic as PIC,
                id_group AS Grup,
                id_sub_group AS SubGrup,
                id_location AS Lokasi,
                id_group_target AS GrupTarget,
                id_sub_group_target AS SubGrupTarget,
                id_location_target AS LokasiTarget,
                user_target AS UserTarget,
                informasi AS Informasi
            FROM move_asset
            """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QueryAsync<MoveAssetResponse>(sql);

            if (result == null || !result.Any())
            {
                return Result.Failure<List<MoveAssetResponse>>(MoveAssetErrors.EmptyData());
            }

            return Result.Success(result.ToList());
        }
    }
}
