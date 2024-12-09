using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.MoveAsset.Application.GetMoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Presentation.MoveAsset
{
    internal class GetAllMoveAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("move/assets", async (ISender sender) =>
            {
                Result<List<MoveAssetResponse>> result = await sender.Send(new GetAllMoveAssetQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.MoveAsset);
        }
    }
}
