using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Modules.Tag.Application.GetGroup;

namespace UnpakAsset.Modules.Tag.Application.GetAllGroup
{
    public sealed record GetAllGroupQuery() : IQuery<List<GroupResponse>>;
}
