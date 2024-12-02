using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Tag.Application.GetGroup
{
    public sealed record GetGroupQuery(Guid GroupId) : IQuery<GroupResponse>;
}
