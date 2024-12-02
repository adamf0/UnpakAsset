using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Tag.Application.UpdateGroup
{
    public sealed record UpdateGroupCommand(
        Guid Id,
        string Nama
    ) : ICommand;

}
