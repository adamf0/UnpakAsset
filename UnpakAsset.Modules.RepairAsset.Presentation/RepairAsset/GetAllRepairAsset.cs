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
    internal class GetAllRepairAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("repair/assets", async (ISender sender) =>
            {
                Result<List<RepairAssetResponse>> result = await sender.Send(new GetAllRepairAssetQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.RepairAsset);
        }
    }
}
