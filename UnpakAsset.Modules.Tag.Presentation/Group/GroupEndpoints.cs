using Microsoft.AspNetCore.Routing;
//using UnpakAsset.Modules.Asset.Presentation.Asset;
using UnpakTag.Modules.Tag.Presentation.Group;

namespace UnpakAsset.Modules.Tag.Presentation.Group
{
    public static class GroupEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateGroup.MapEndpoint(app);
            UpdateGroup.MapEndpoint(app);
            DeleteGroup.MapEndpoint(app);
            GetGroup.MapEndpoint(app);
            GetAllGroup.MapEndpoint(app);
        }
    }
}
