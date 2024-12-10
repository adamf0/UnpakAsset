using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Application.GetDisposalAsset;
using UnpakAsset.Modules.DisposalAsset.Application.GetDisposalAsset;
using UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Application.GetAllDisposalAsset
{
    internal sealed class GetAllDisposalAssetQueryHandler(IDbConnectionFactory _dbConnectionFactory) : IQueryHandler<GetAllDisposalAssetQuery, List<DisposalAssetResponse>>
    {
        public async Task<Result<List<DisposalAssetResponse>>> Handle(GetAllDisposalAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync();

            const string sql =
            """
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
            """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QueryAsync<DisposalAssetResponse>(sql);

            if (result == null || !result.Any())
            {
                return Result.Failure<List<DisposalAssetResponse>>(DisposalAssetErrors.EmptyData());
            }

            return Result.Success(result.ToList());
        }
    }
}
