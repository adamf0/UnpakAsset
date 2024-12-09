using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Application.GetPhysicalAsset;
using UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Application.GetPhysicalAsset
{
    internal sealed class GetPhysicalAssetQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetPhysicalAssetQuery, PhysicalAssetResponse>
    {
        public async Task<Result<PhysicalAssetResponse>> Handle(GetPhysicalAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            //CAST(NULLIF(id_group, '') AS CHAR(36)) -> guid
            const string sql =
                $"""
             SELECT 
                 CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                 type AS Tipe,
                 tanggal_mulai AS TanggalMulai,
                 tanggal_akhir AS TanggalAkhir,
                 pic as PIC,
                 id_group AS Grup,
                 id_sub_group AS SubGrup,
                 id_location AS Lokasi,
                 informasi AS Informasi
             FROM physical_asset
             WHERE id = @Id
             """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<PhysicalAssetResponse?>(sql, new { Id = request.PhysicalAssetId });
            if (result == null)
            {
                return Result.Failure<PhysicalAssetResponse>(PhysicalAssetErrors.NotFound(request.PhysicalAssetId));
            }

            return result;
        }
    }
}
