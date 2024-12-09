using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.GetPhysicalAsset;
using UnpakAsset.Modules.PhysicalAsset.Application.GetPhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Presentation.PhysicalAsset
{
    internal static class GetPhysicalAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("physical/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result<PhysicalAssetResponse> result = await sender.Send(new GetPhysicalAssetQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.PhysicalAsset);
        }
    }

}
