using Microsoft.AspNetCore.Routing;

namespace UnpakAsset.Modules.AssignAsset.Presentation.AssignAsset
{
    public static class AssignAssetEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateAssignAsset.MapEndpoint(app);
            UpdateAssignAsset.MapEndpoint(app);
            DeleteAssignAsset.MapEndpoint(app);
            GetAssignAsset.MapEndpoint(app);
            GetAllAssignAsset.MapEndpoint(app);
        }
    }
}
