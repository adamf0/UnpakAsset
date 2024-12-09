using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Modules.AssignAsset.Application.GetRepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Application.GetRepairAsset
{
    public sealed record GetAllRepairAssetQuery() : IQuery<List<RepairAssetResponse>>;
}
