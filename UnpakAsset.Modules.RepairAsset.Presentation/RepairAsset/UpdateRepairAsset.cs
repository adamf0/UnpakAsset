using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.RepairAsset.Application.UpdateRepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Presentation.RepairAsset
{
    internal static class UpdateRepairAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("repair/asset", async (UpdateRepairAssetRequest request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdateRepairAssetCommand(
                    request.Id,
                    request.Tipe,
                    request.PIC,
                    request.Grup,
                    request.SubGrup,
                    request.Lokasi,
                    request.Informasi
                    )
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.RepairAsset);
        }

        internal sealed class UpdateRepairAssetRequest
        {
            public Guid Id { get; set; }
            public string Tipe { get; set; } = null!;
            public string PIC { get; set; } = null!;
            public string? Grup { get; set; }
            public string? SubGrup { get; set; }
            public string? Lokasi { get; set; }
            public string Informasi { get; set; } = null!;
        }
    }
}
