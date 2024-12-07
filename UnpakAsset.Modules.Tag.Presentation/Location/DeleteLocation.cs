using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.Tag.Application.DeleteLocation;

namespace UnpakAsset.Modules.Tag.Presentation.Location
{
    internal class DeleteLocation
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("location/{id}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(
                    new DeleteLocationCommand(id)
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.Location);
        }
    }
}
