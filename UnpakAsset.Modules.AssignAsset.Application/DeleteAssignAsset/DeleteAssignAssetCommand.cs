using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.AssignAsset.Application.DeleteAssignAsset
{
    public sealed record DeleteAssignAssetCommand(
        Guid Id
    ) : ICommand;
}
