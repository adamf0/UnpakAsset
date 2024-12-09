using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.PhysicalAsset.Application.DeletePhysicalAsset
{
    public sealed record DeletePhysicalAssetCommand(
        Guid Id
    ) : ICommand;
}
