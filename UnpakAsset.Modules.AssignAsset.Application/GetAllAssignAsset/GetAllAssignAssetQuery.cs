using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.AssignAsset.Application.GetAssignAsset
{
    public sealed record GetAllAssignAssetQuery() : IQuery<List<AssignAssetResponse>>;
}
