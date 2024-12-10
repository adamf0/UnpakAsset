using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.DisposalAsset.Application.CreateDisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Presentation.DisposalAsset
{
    internal static class CreateDisposalAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("disposal/asset", async (CreateDisposalAssetRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateDisposalAssetCommand(
                    request.Tiket,
                    request.Tipe,
                    request.PIC,
                    request.Grup,
                    request.SubGrup,
                    request.Lokasi,
                    request.Informasi
                    )
                );

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.DisposalAsset);
        }

        internal sealed class CreateDisposalAssetRequest
        {
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
