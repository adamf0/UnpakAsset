using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.PhysicalAsset.Application.UpdatePhysicalAsset
{
    public sealed record UpdatePhysicalAssetCommand(
        Guid Id,
        string Tipe,
        string TanggalMulai,
        string TanggalAkhir,
        string PIC,
        string? Grup,
        string? SubGrup,
        string? Lokasi,
        string Informasi
    ) : ICommand;
}
