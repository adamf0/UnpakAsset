//using UnpakAsset.Modules.User.Domain.Abstractions;

//using UnpakAsset.Modules.User.Domain.Abstractions;

//using UnpakAsset.Modules.User.Domain.Abstractions;

//using UnpakAsset.Modules.User.Domain.Abstractions;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.Tag.Domain.Group
{
    public sealed class GroupCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }

}
