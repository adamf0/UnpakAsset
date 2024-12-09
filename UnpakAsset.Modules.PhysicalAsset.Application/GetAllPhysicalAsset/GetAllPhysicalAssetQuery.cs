using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Modules.AssignAsset.Application.GetPhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Application.GetPhysicalAsset
{
    public sealed record GetAllPhysicalAssetQuery() : IQuery<List<PhysicalAssetResponse>>;
}
