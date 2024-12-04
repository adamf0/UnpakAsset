using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.MoveAsset.Application.DeleteMoveAsset
{
    public sealed record DeleteMoveAssetCommand(
        Guid Id
    ) : ICommand;
}
