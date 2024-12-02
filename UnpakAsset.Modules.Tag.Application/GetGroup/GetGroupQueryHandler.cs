using Dapper;
using UnpakAsset.Common.Application.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using System.Data.Common;
using UnpakAsset.Modules.Tag.Domain.Group;

namespace UnpakAsset.Modules.Tag.Application.GetGroup
{
    internal sealed class GetGroupQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetGroupQuery, GroupResponse>
    {
        public async Task<Result<GroupResponse>> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            //CAST(NULLIF(id_group, '') AS CHAR(36)) -> guid
            const string sql =
                $"""
             SELECT 
                 CAST(NULLIF(id, '') AS VARCHAR(36)) AS Id,
                 nama
             FROM `group`
             WHERE id = @Id
             """;

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<GroupResponse?>(sql, new { Id = request.GroupId });
            if (result == null)
            {
                return Result.Failure<GroupResponse>(GroupErrors.NotFound(request.GroupId));
            }

            return result;
        }
    }
}
