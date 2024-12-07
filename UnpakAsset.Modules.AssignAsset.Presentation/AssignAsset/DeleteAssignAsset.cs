using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.DeleteAssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Presentation.AssignAsset
{
    internal class DeleteAssignAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("assign/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(
                    new DeleteAssignAssetCommand(id)
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.AssignAsset);
        }
    }
}
