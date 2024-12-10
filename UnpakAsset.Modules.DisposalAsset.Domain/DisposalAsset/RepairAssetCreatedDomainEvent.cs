using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset
{
    public sealed class DisposalAssetCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }
}
