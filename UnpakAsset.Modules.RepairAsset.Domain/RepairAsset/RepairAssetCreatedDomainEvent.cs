using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.RepairAsset.Domain.RepairAsset
{
    public sealed class RepairAssetCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }
}
