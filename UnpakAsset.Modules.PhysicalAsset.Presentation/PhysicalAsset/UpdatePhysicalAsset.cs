using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.PhysicalAsset.Application.UpdatePhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Presentation.PhysicalAsset
{
    internal static class UpdatePhysicalAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("physical/asset", async (UpdatePhysicalAssetRequest request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdatePhysicalAssetCommand(
                    request.Id,
                    request.Tipe,
                    request.TanggalMulai,
                    request.TanggalAkhir,
                    request.PIC,
                    request.Grup,
                    request.SubGrup,
                    request.Lokasi,
                    request.Informasi
                    )
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.PhysicalAsset);
        }

        internal sealed class UpdatePhysicalAssetRequest
        {
            public Guid Id { get; set; }
            public string Tipe { get; set; } = null!;
            public string TanggalMulai { get; set; }
            public string TanggalAkhir { get; set; }
            public string PIC { get; set; } = null!;
            public string? Grup { get; set; }
            public string? SubGrup { get; set; }
            public string? Lokasi { get; set; }
            public string Informasi { get; set; } = null!;
        }
    }
}
