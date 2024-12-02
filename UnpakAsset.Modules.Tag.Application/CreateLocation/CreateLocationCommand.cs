using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Tag.Application.CreateLocation
{
    public sealed record CreateLocationCommand(
        string Nama
    ) : ICommand<Guid>;
}
