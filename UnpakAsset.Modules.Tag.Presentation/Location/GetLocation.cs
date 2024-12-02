using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.Tag.Application.GetLocation;

namespace UnpakAsset.Modules.Tag.Presentation.Location
{
    internal static class GetLocation
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("location/{id}", async (Guid id, ISender sender) =>
            {
                Result<LocationResponse> result = await sender.Send(new GetLocationQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            });
        }
    }
}
