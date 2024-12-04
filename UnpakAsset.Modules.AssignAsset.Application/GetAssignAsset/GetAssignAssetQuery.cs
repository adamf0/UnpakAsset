using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.AssignAsset.Application.GetAssignAsset
{
    public sealed record GetAssignAssetQuery(Guid AssignAssetId) : IQuery<AssignAssetResponse>;
}
