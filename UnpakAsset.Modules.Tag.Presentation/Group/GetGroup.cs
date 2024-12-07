using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Application.GetGroup;
using UnpakAsset.Common.Presentation.ApiResults;

namespace UnpakAsset.Modules.Tag.Presentation.Group
{
    internal static class GetGroup
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("group/{id}", async (Guid id, ISender sender) =>
            {
                Result<GroupResponse> result = await sender.Send(new GetGroupQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.Group);
        }
    }

}
