using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.Tag.Application.UpdateLocation;

namespace UnpakAsset.Modules.Tag.Presentation.Location
{
    internal static class UpdateLocation
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("location", async (UpdateLocationRequest request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdateLocationCommand(
                    request.Id,
                    request.Nama
                    )
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            });
        }

        internal sealed class UpdateLocationRequest
        {
            public Guid Id { get; set; }
            public string Nama { get; set; }
        }
    }
}
