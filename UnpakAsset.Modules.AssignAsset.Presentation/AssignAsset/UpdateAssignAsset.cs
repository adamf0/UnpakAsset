using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.AssignAsset.Application.UpdateAssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Presentation.AssignAsset
{
    internal static class UpdateAssignAsset
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("assign/asset", async (UpdateAssignAssetRequest request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdateAssignAssetCommand(
                    request.Id,
                    request.Nidn,
                    request.Nip,
                    request.Fakultas,
                    request.Prodi,
                    request.Unit,
                    request.Barcode
                    )
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.AssignAsset);
        }

        internal sealed class UpdateAssignAssetRequest
        {
            public Guid Id { get; set; }
            public string? Nidn { get; set; }

            public string? Nip { get; set; }

            public string? Fakultas { get; set; }

            public string? Prodi { get; set; }

            public string? Unit { get; set; }
            public string Barcode { get; set; }
        }
    }
}
