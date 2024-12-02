using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.Asset.Application.CreateAsset
{
    public sealed record CreateAssetCommand(
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
    ) : ICommand<Guid>;

}
