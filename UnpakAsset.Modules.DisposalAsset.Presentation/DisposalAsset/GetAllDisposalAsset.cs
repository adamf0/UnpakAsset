using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.GetDisposalAsset;
using UnpakAsset.Modules.DisposalAsset.Application.GetDisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Presentation.DisposalAsset
{
    internal class GetAllDisposalAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("disposal/assets", async (ISender sender) =>
            {
                Result<List<DisposalAssetResponse>> result = await sender.Send(new GetAllDisposalAssetQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.DisposalAsset);
        }
    }
}
