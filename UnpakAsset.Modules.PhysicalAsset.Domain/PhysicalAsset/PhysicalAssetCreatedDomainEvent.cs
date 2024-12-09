using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset
{
    public sealed class PhysicalAssetCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }
}
