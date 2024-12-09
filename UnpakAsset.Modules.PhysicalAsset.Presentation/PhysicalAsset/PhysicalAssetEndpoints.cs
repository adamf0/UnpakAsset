using Microsoft.AspNetCore.Routing;

namespace UnpakAsset.Modules.PhysicalAsset.Presentation.PhysicalAsset
{
    public static class PhysicalAssetEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreatePhysicalAsset.MapEndpoint(app);
            UpdatePhysicalAsset.MapEndpoint(app);
            DeletePhysicalAsset.MapEndpoint(app);
            GetPhysicalAsset.MapEndpoint(app);
            GetAllPhysicalAsset.MapEndpoint(app);
        }
    }
}
