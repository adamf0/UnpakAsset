using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.MoveAsset.Application.CreateMoveAsset
{
    public sealed record CreateMoveAssetCommand(
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
    ) : ICommand<Guid>;
}
