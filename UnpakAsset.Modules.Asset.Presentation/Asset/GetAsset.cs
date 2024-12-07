using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Asset.Application.GetAsset;
using UnpakAsset.Common.Presentation.ApiResults;

namespace UnpakAsset.Modules.Asset.Presentation.Asset
{
    internal static class GetAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("asset/{id}", async (Guid id, ISender sender) =>
            {
                Result<AssetResponse> result = await sender.Send(new GetAssetQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.Asset);
        }
    }

}
