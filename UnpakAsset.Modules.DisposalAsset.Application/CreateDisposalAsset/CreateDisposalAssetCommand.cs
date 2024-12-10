using UnpakAsset.Common.Application.Messaging;

namespace UnpakAsset.Modules.DisposalAsset.Application.CreateDisposalAsset
{
    public sealed record CreateDisposalAssetCommand(
        string? Tiket,
        string Tipe,
        string PIC,
        string? Grup,
        string? SubGrup,
        string? Lokasi,
        string Informasi
    ) : ICommand<Guid>;
}
