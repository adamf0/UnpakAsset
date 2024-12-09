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
    internal class GetAllPhysicalAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("physical/assets", async (ISender sender) =>
            {
                Result<List<PhysicalAssetResponse>> result = await sender.Send(new GetAllPhysicalAssetQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.PhysicalAsset);
        }
    }
}
