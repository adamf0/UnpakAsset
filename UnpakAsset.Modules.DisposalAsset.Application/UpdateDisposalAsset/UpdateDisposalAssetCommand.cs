using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.DisposalAsset.Application.UpdateDisposalAsset
{
    public sealed record UpdateDisposalAssetCommand(
        Guid Id,
        string? Tiket,
        string Tipe,
        string PIC,
        string? Grup,
        string? SubGrup,
        string? Lokasi,
        string Informasi
    ) : ICommand;
}
