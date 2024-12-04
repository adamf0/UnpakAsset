using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Asset.Application.DeleteAsset;
using UnpakAsset.Common.Presentation.ApiResults;

namespace UnpakAsset.Modules.Asset.Presentation.Asset
{
    internal class DeleteAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("asset/{id}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(
                    new DeleteAssetCommand(id)
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags("asset.delete");
        }
    }
}
