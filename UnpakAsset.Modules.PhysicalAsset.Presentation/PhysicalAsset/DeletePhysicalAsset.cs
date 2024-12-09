using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.PhysicalAsset.Application.DeletePhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Presentation.PhysicalAsset
{
    internal class DeletePhysicalAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("physical/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(
                    new DeletePhysicalAssetCommand(id)
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.PhysicalAsset);
        }
    }
}
