using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Tag.Application.DeleteGroup
{
    public sealed record DeleteGroupCommand(
        Guid Id
    ) : ICommand;

}
