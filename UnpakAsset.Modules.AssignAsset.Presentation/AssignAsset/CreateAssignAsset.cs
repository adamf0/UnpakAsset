using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.CreateAssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Presentation.AssignAsset
{
    internal static class CreateAssignAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("assign/asset", async (CreateAssignAssetRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateAssignAssetCommand(
                    request.Nidn,
                    request.Nip,
                    request.Fakultas,
                    request.Prodi,
                    request.Unit,
                    request.Barcode
                    )
                );

                return result.Match(Results.Ok, ApiResults.Problem);
            });
        }

        internal sealed class CreateAssignAssetRequest
        {
            public string? Nidn { get; set; }

            public string? Nip { get; set; }

            public string? Fakultas { get; set; }

            public string? Prodi { get; set; }

            public string? Unit { get; set; }
            public string Barcode { get; set; }
        }
    }

}
