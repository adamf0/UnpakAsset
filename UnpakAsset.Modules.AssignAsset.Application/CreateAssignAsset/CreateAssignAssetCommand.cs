using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.AssignAsset.Application.CreateAssignAsset
{
    public sealed record CreateAssignAssetCommand(
        string? Nidn,
        string? Nip,
        string? Fakultas,
        string? Prodi,
        string? Unit,
        string Barcode
    ) : ICommand<Guid>;
}
