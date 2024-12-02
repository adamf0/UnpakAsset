//using UnpakAsset.Modules.User.Domain.Abstractions;

//using UnpakAsset.Modules.User.Domain.Abstractions;

//using UnpakAsset.Modules.User.Domain.Abstractions;

//using UnpakAsset.Modules.User.Domain.Abstractions;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.Tag.Domain.Location
{
    public sealed class LocationCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }

}
