using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.RepairAsset.Application.UpdateRepairAsset
{
    public sealed record UpdateRepairAssetCommand(
        Guid Id,
        string Tipe,
        string PIC,
        string? Grup,
        string? SubGrup,
        string? Lokasi,
        string Informasi
    ) : ICommand;
}
