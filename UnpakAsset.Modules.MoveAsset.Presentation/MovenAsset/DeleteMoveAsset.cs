using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.MoveAsset.Application.DeleteMoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Presentation.MoveAsset
{
    internal class DeleteMoveAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("move/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(
                    new DeleteMoveAssetCommand(id)
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.MoveAsset);
        }
    }
}
