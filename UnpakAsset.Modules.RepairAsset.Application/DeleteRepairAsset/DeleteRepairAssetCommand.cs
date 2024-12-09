using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.RepairAsset.Application.DeleteRepairAsset
{
    public sealed record DeleteRepairAssetCommand(
        Guid Id
    ) : ICommand;
}
