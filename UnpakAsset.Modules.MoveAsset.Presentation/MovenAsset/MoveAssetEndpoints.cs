using Microsoft.AspNetCore.Routing;

namespace UnpakAsset.Modules.MoveAsset.Presentation.MoveAsset
{
    public static class MoveAssetEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateMoveAsset.MapEndpoint(app);
            UpdateMoveAsset.MapEndpoint(app);
            DeleteMoveAsset.MapEndpoint(app);
            GetMoveAsset.MapEndpoint(app);
            GetAllMoveAsset.MapEndpoint(app);
        }
    }
}
