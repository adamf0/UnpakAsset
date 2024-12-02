//using UnpakAsset.Modules.User.Domain.Abstractions;

//using UnpakAsset.Modules.User.Domain.Abstractions;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.Asset.Domain.Asset
{
    public sealed class AssetCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }

}
