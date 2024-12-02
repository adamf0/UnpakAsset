using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Modules.Asset.Application.GetAsset;

namespace UnpakAsset.Modules.Asset.Application.GetAllAsset
{
    public sealed record GetAllAssetQuery() : IQuery<List<AssetResponse>>;
}
