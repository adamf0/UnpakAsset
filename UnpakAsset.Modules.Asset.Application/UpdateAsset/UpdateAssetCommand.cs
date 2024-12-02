using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Asset.Application.UpdateAsset
{
    public sealed record UpdateAssetCommand(
        Guid Id,
        string Nama,
        string TanggalTerdaftar,
        string Kondisi,
        string KodeAset,
        string? Grup,
        string? SubGrup,
        string? Lokasi,
        string? PO,
        string HargaPerUnit,
        string TotalUnit
    ) : ICommand;

}
