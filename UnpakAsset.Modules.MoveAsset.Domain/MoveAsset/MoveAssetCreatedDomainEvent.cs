using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.MoveAsset.Domain.MoveAsset
{
    public sealed class MoveAssetCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }
}
