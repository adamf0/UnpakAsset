using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Modules.AssignAsset.Application.GetMoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Application.GetMoveAsset
{
    public sealed record GetMoveAssetQuery(Guid MoveAssetId) : IQuery<MoveAssetResponse>;
}
