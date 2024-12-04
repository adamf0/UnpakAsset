using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.AssignAsset.Application.UpdateAssignAsset
{
    public sealed record UpdateAssignAssetCommand(
        Guid Id,
        string? Nidn,
        string? Nip,
        string? Fakultas,
        string? Prodi,
        string? Unit,
        string Barcode
    ) : ICommand;
}
