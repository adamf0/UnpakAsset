using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Asset.Application.GetAllAsset;
using UnpakAsset.Modules.Asset.Application.GetAsset;
using UnpakAsset.Common.Presentation.ApiResults;

namespace UnpakAsset.Modules.Asset.Presentation.Asset
{
    internal class GetAllAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("assets", async (ISender sender) =>
            {
                Result<List<AssetResponse>> result = await sender.Send(new GetAllAssetQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            });
        }
    }
}
