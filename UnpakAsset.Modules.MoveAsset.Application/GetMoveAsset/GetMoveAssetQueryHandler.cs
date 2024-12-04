using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Application.GetMoveAsset;
using UnpakAsset.Modules.MoveAsset.Domain.MoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Application.GetMoveAsset
{
    internal sealed class GetMoveAssetQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetMoveAssetQuery, MoveAssetResponse>
    {
        public async Task<Result<MoveAssetResponse>> Handle(GetMoveAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            //CAST(NULLIF(id_group, '') AS CHAR(36)) -> guid
            const string sql =
                $"""
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
             WHERE id = @Id
             """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<MoveAssetResponse?>(sql, new { Id = request.MoveAssetId });
            if (result == null)
            {
                return Result.Failure<MoveAssetResponse>(MoveAssetErrors.NotFound(request.MoveAssetId));
            }

            return result;
        }
    }
}
