using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Application.GetPhysicalAsset;
using UnpakAsset.Modules.PhysicalAsset.Application.GetPhysicalAsset;
using UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Application.GetAllPhysicalAsset
{
    internal sealed class GetAllPhysicalAssetQueryHandler(IDbConnectionFactory _dbConnectionFactory) : IQueryHandler<GetAllPhysicalAssetQuery, List<PhysicalAssetResponse>>
    {
        public async Task<Result<List<PhysicalAssetResponse>>> Handle(GetAllPhysicalAssetQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync();

            const string sql =
            """
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
            """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QueryAsync<PhysicalAssetResponse>(sql);

            if (result == null || !result.Any())
            {
                return Result.Failure<List<PhysicalAssetResponse>>(PhysicalAssetErrors.EmptyData());
            }

            return Result.Success(result.ToList());
        }
    }
}
