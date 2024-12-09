using Microsoft.AspNetCore.Routing;

namespace UnpakAsset.Modules.RepairAsset.Presentation.RepairAsset
{
    public static class RepairAssetEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateRepairAsset.MapEndpoint(app);
            UpdateRepairAsset.MapEndpoint(app);
            DeleteRepairAsset.MapEndpoint(app);
            GetRepairAsset.MapEndpoint(app);
            GetAllRepairAsset.MapEndpoint(app);
        }
    }
}
