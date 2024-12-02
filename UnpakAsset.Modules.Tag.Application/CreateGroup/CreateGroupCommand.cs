using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Tag.Application.CreateGroup
{
    public sealed record CreateGroupCommand(
        string Nama
    ) : ICommand<Guid>;

}
