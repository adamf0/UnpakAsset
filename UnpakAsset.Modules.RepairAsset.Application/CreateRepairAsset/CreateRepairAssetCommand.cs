using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.RepairAsset.Application.CreateRepairAsset
{
    public sealed record CreateRepairAssetCommand(
        string Tipe,
        string PIC,
        string? Grup,
        string? SubGrup,
        string? Lokasi,
        string Informasi
    ) : ICommand<Guid>;
}
