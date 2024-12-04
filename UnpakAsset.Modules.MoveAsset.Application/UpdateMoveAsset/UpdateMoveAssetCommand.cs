using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.MoveAsset.Application.UpdateMoveAsset
{
    public sealed record UpdateMoveAssetCommand(
        Guid Id,
        string? Tiket,
        string Tipe,
        string PIC,
        string? Grup,
        string? SubGrup,
        string? Lokasi,
        string? GrupTarget,
        string? SubGrupTarget,
        string? LokasiTarget,
        string? UserTarget,
        string Informasi
    ) : ICommand;
}
