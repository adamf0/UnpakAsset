using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.DisposalAsset.Application.DeleteDisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Presentation.DisposalAsset
{
    internal class DeleteDisposalAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("disposal/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(
                    new DeleteDisposalAssetCommand(id)
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.DisposalAsset);
        }
    }
}
