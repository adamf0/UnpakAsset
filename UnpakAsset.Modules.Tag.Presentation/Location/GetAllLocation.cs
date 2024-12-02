using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.Tag.Application.GetAllLocation;
using UnpakAsset.Modules.Tag.Application.GetLocation;

namespace UnpakAsset.Modules.Tag.Presentation.Location
{
    internal class GetAllLocation
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("locations", async (ISender sender) =>
            {
                Result<List<LocationResponse>> result = await sender.Send(new GetAllLocationQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            });
        }
    }
}
