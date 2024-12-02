using Dapper;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using System.Data.Common;
using UnpakAsset.Modules.Tag.Domain.Group;
using UnpakAsset.Modules.Tag.Application.GetGroup;

namespace UnpakAsset.Modules.Tag.Application.GetAllGroup
{
    internal sealed class GetAllGroupQueryHandler(IDbConnectionFactory _dbConnectionFactory) : IQueryHandler<GetAllGroupQuery, List<GroupResponse>>
    {
        public async Task<Result<List<GroupResponse>>> Handle(GetAllGroupQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync();

            const string sql =
            """
            SELECT 
                CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                nama 
            FROM `group` 
            """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QueryAsync<GroupResponse>(sql);

            if (result == null || !result.Any())
            {
                return Result.Failure<List<GroupResponse>>(GroupErrors.EmptyData());
            }

            return Result.Success(result.ToList());
        }
    }
}
