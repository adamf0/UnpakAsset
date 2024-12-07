using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Application.UpdateGroup;
using UnpakAsset.Common.Presentation.ApiResults;

namespace UnpakAsset.Modules.Tag.Presentation.Group
{
    internal static class UpdateGroup
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("group", async (UpdateGroupRequest request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdateGroupCommand(
                    request.Id,
                    request.Nama
                    )
                );

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            }).WithTags(Tags.Group);
        }

        internal sealed class UpdateGroupRequest
        {
            public Guid Id { get; set; }
            public string Nama { get; set; }
        }
    }
}
