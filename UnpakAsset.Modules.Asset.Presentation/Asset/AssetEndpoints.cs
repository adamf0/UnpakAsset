using Microsoft.AspNetCore.Routing;

namespace UnpakAsset.Modules.Asset.Presentation.Asset
{
    public static class AssetEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateAsset.MapEndpoint(app);
            UpdateAsset.MapEndpoint(app);
            DeleteAsset.MapEndpoint(app);
            GetAsset.MapEndpoint(app);
            GetAllAsset.MapEndpoint(app);
        }
    }
}
