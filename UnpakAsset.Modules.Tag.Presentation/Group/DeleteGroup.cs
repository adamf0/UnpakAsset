using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.Tag.Application.DeleteGroup;

namespace UnpakAsset.Modules.Tag.Presentation.Group
{
    internal class DeleteGroup
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("group/{id}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(
                    new DeleteGroupCommand(id)
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.Group);
        }
    }
}
