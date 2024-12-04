using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.GetAssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Presentation.AssignAsset
{
    internal class GetAllAssignAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("assign/assets", async (ISender sender) =>
            {
                Result<List<AssignAssetResponse>> result = await sender.Send(new GetAllAssignAssetQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            });
        }
    }
}
