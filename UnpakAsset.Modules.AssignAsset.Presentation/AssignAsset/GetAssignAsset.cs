using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.GetAssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Presentation.AssignAsset
{
    internal static class GetAssignAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("assign/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result<AssignAssetResponse> result = await sender.Send(new GetAssignAssetQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.AssignAsset);
        }
    }

}
