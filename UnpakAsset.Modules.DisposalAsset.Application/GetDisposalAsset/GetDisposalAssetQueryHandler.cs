using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Application.GetDisposalAsset;
using UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Application.GetDisposalAsset
{
    internal sealed class GetDisposalAssetQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetDisposalAssetQuery, DisposalAssetResponse>
    {
        public async Task<Result<DisposalAssetResponse>> Handle(GetDisposalAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            //CAST(NULLIF(id_group, '') AS CHAR(36)) -> guid
            const string sql =
                $"""
             SELECT 
                 CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                 id_ticket AS Tiket,
                 type AS Tipe,
                 pic as PIC,
                 id_group AS Grup,
                 id_sub_group AS SubGrup,
                 id_location AS Lokasi,
                 informasi AS Informasi
             FROM disposal_asset
             WHERE id = @Id
             """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<DisposalAssetResponse?>(sql, new { Id = request.DisposalAssetId });
            if (result == null)
            {
                return Result.Failure<DisposalAssetResponse>(DisposalAssetErrors.NotFound(request.DisposalAssetId));
            }

            return result;
        }
    }
}
