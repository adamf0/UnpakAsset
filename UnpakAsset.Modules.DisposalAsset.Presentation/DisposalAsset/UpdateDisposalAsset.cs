using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.DisposalAsset.Application.UpdateDisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Presentation.DisposalAsset
{
    internal static class UpdateDisposalAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("disposal/asset", async (UpdateDisposalAssetRequest request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdateDisposalAssetCommand(
                    request.Id,
                    request.Tiket,
                    request.Tipe,
                    request.PIC,
                    request.Grup,
                    request.SubGrup,
                    request.Lokasi,
                    request.Informasi
                    )
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.DisposalAsset);
        }

        internal sealed class UpdateDisposalAssetRequest
        {
            public Guid Id { get; set; }
            public string? Tiket { get; set; }
            public string Tipe { get; set; } = null!;
            public string PIC { get; set; } = null!;
            public string? Grup { get; set; }
            public string? SubGrup { get; set; }
            public string? Lokasi { get; set; }
            public string Informasi { get; set; } = null!;
        }
    }
}
