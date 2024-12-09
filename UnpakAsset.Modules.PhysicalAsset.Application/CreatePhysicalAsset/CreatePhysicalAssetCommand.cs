using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.PhysicalAsset.Application.CreatePhysicalAsset
{
    public sealed record CreatePhysicalAssetCommand(
        string Tipe,
        string TanggalMulai,
        string TanggalAkhir,
        string PIC,
        string? Grup,
        string? SubGrup,
        string? Lokasi,
        string Informasi
    ) : ICommand<Guid>;
}
