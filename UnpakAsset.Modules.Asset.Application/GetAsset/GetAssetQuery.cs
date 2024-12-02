using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Asset.Application.GetAsset
{
    public sealed record GetAssetQuery(Guid AssetId) : IQuery<AssetResponse>;
}
