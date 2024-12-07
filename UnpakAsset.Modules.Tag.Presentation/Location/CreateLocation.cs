using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.Tag.Application.CreateLocation;

namespace UnpakAsset.Modules.Tag.Presentation.Location
{
    internal static class CreateLocation
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("location", async (CreateLocationRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateLocationCommand(
                    request.Nama
                    )
                );

                return result.Match(Results.Ok, ApiResults.Problem);
            }).WithTags(Tags.Location);
        }

        internal sealed class CreateLocationRequest
        {
            public string Nama { get; set; }

        }
    }
}
