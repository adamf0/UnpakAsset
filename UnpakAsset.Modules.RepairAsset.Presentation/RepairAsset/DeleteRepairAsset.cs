using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.RepairAsset.Application.DeleteRepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Presentation.RepairAsset
{
    internal class DeleteRepairAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("repair/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(
                    new DeleteRepairAssetCommand(id)
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.RepairAsset);
        }
    }
}
