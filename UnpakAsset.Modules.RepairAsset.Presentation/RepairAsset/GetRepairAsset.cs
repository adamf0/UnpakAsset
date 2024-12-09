using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.GetRepairAsset;
using UnpakAsset.Modules.RepairAsset.Application.GetRepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Presentation.RepairAsset
{
    internal static class GetRepairAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("repair/asset/{id}", async (Guid id, ISender sender) =>
            {
                Result<RepairAssetResponse> result = await sender.Send(new GetRepairAssetQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.RepairAsset);
        }
    }

}
