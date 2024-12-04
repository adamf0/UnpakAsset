using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.Asset.Application.CreateAsset;

namespace UnpakAsset.Modules.Asset.Presentation.Asset
{
    internal static class CreateAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("asset", async (CreateAssetRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateAssetCommand(
                    request.Nama,
                    request.TanggalTerdaftar,
                    request.Kondisi,
                    request.KodeAsset,
                    request.Grup,
                    request.SubGrup,
                    request.Lokasi,
                    request.PO,
                    request.HargaPerUnit,
                    request.TotalUnit
                    )
                );

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags("asset.create");
        }

        internal sealed class CreateAssetRequest
        {
            public string Nama { get; set; }

            public string TanggalTerdaftar { get; set; }

            public string Kondisi { get; set; }

            public string KodeAsset { get; set; }

            public string? Grup { get; set; }
            public string? SubGrup { get; set; }
            public string? Lokasi { get; set; }
            public string? PO { get; set; }
            public string HargaPerUnit { get; set; }
            public string TotalUnit { get; set; }
        }
    }

}
