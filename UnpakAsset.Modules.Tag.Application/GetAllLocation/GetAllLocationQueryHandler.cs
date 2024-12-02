using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Application.GetAllLocation;
using UnpakAsset.Modules.Tag.Application.GetLocation;
using UnpakAsset.Modules.Tag.Domain.Location;

namespace UnpakAsset.Modules.Tag.Application.GetAllLocation
{
    internal sealed class GetAllLocationQueryHandler(IDbConnectionFactory _dbConnectionFactory) : IQueryHandler<GetAllLocationQuery, List<LocationResponse>>
    {
        public async Task<Result<List<LocationResponse>>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync();

            const string sql =
            """
            SELECT 
                CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                nama 
            FROM `location` 
            """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QueryAsync<LocationResponse>(sql);

            if (result == null || !result.Any())
            {
                return Result.Failure<List<LocationResponse>>(LocationErrors.EmptyData());
            }

            return Result.Success(result.ToList());
        }
    }
}
