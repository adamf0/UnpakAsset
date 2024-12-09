using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.RepairAsset.Application.CreateRepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Presentation.RepairAsset
{
    internal static class CreateRepairAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("repair/asset", async (CreateRepairAssetRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateRepairAssetCommand(
                    request.Tipe,
                    request.PIC,
                    request.Grup,
                    request.SubGrup,
                    request.Lokasi,
                    request.Informasi
                    )
                );

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.RepairAsset);
        }

        internal sealed class CreateRepairAssetRequest
        {
            public string Tipe { get; set; } = null!;
            public string PIC { get; set; } = null!;
            public string? Grup { get; set; }
            public string? SubGrup { get; set; }
            public string? Lokasi { get; set; }
            public string Informasi { get; set; } = null!;
        }
    }

}
