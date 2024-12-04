using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.AssignAsset.Domain.AssignAsset
{
    public sealed class AssignAssetCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }
}
