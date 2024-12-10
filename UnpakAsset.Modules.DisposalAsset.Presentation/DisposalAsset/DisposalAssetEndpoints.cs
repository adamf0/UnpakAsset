using Microsoft.AspNetCore.Routing;

namespace UnpakAsset.Modules.DisposalAsset.Presentation.DisposalAsset
{
    public static class DisposalAssetEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateDisposalAsset.MapEndpoint(app);
            UpdateDisposalAsset.MapEndpoint(app);
            DeleteDisposalAsset.MapEndpoint(app);
            GetDisposalAsset.MapEndpoint(app);
            GetAllDisposalAsset.MapEndpoint(app);
        }
    }
}
