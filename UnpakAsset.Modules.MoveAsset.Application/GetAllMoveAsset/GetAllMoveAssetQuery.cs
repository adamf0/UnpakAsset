using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Modules.MoveAsset.Application.GetMoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Application.GetMoveAsset
{
    public sealed record GetAllMoveAssetQuery() : IQuery<List<MoveAssetResponse>>;
}
