using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.MoveAsset.Application.CreateMoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Presentation.MoveAsset
{
    internal static class CreateMoveAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("move/asset", async (CreateMoveAssetRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateMoveAssetCommand(
                    request.Tiket,
                    request.Tipe,
                    request.PIC,
                    request.Grup,
                    request.SubGrup,
                    request.Lokasi,
                    request.GrupTarget,
                    request.SubGrupTarget,
                    request.LokasiTarget,
                    request.UserTarget,
                    request.Informasi
                    )
                );

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.MoveAsset);
        }

        internal sealed class CreateMoveAssetRequest
        {
            public string? Tiket { get; set; }
            public string Tipe { get; set; } = null!;
            public string PIC { get; set; } = null!;
            public string? Grup { get; set; }
            public string? SubGrup { get; set; }
            public string? Lokasi { get; set; }
            public string? GrupTarget { get; set; }
            public string? SubGrupTarget { get; set; }
            public string? LokasiTarget { get; set; }
            public string? UserTarget { get; set; }
            public string Informasi { get; set; } = null!;
        }
    }

}
