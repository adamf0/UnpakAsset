using Microsoft.AspNetCore.Routing;

namespace UnpakAsset.Modules.Tag.Presentation.Location
{
    public static class LocationEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateLocation.MapEndpoint(app);
            UpdateLocation.MapEndpoint(app);
            DeleteLocation.MapEndpoint(app);
            GetLocation.MapEndpoint(app);
            GetAllLocation.MapEndpoint(app);
        }
    }
}
