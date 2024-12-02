using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Tag.Application.UpdateLocation
{
    public sealed record UpdateLocationCommand(
        Guid Id,
        string Nama
    ) : ICommand;
}
