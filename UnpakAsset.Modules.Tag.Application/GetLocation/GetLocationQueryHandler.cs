using Dapper;
using System.Data.Common;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Domain.Location;

namespace UnpakAsset.Modules.Tag.Application.GetLocation
{
    internal sealed class GetLocationQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetLocationQuery, LocationResponse>
    {
        public async Task<Result<LocationResponse>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            //CAST(NULLIF(id_location, '') AS CHAR(36)) -> guid
            const string sql =
                $"""
             SELECT 
                 CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                 nama
             FROM `location`
             WHERE id = @Id
             """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<LocationResponse?>(sql, new { Id = request.LocationId });
            if (result == null)
            {
                return Result.Failure<LocationResponse>(LocationErrors.NotFound(request.LocationId));
            }

            return result;
        }
    }
}
