using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Presentation.ApiResults;
using UnpakAsset.Modules.Tag.Application.CreateGroup;

namespace UnpakTag.Modules.Tag.Presentation.Group
{
    internal static class CreateGroup
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("group", async (CreateGroupRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateGroupCommand(
                    request.Nama
                    )
                );

                return result.Match(Results.Ok, ApiResults.Problem);
            });
        }

        internal sealed class CreateGroupRequest
        {
            public string Nama { get; set; }

        }
    }

}
