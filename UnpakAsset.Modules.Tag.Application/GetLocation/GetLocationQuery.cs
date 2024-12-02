using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Tag.Application.GetLocation
{
    public sealed record GetLocationQuery(Guid LocationId) : IQuery<LocationResponse>;
}
