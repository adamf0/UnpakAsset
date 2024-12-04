using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.GetMoveAsset;
using UnpakAsset.Modules.MoveAsset.Application.GetMoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Presentation.MoveAsset
{
    internal static class GetMoveAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("move/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result<MoveAssetResponse> result = await sender.Send(new GetMoveAssetQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            });
        }
    }

}
