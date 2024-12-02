using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Asset.Application.DeleteAsset
{
    public sealed record DeleteAssetCommand(
        Guid Id
    ) : ICommand;

}
