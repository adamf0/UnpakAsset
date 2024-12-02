using UnpakAsset.Common.Application.Messaging;
namespace UnpakAsset.Modules.Tag.Application.DeleteLocation
{
    public sealed record DeleteLocationCommand(
        Guid Id
    ) : ICommand;
}
