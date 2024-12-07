using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Application.GetAllGroup;
using UnpakAsset.Modules.Tag.Application.GetGroup;
using UnpakAsset.Common.Presentation.ApiResults;

namespace UnpakAsset.Modules.Tag.Presentation.Group
{
    internal class GetAllGroup
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("groups", async (ISender sender) =>
            {
                Result<List<GroupResponse>> result = await sender.Send(new GetAllGroupQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.Group);
        }
    }
}
