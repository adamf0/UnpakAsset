using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.DisposalAsset.Application.DeleteDisposalAsset
{
    public sealed record DeleteDisposalAssetCommand(
        Guid Id
    ) : ICommand;
}
