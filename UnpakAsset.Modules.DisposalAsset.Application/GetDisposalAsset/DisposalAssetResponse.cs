namespace UnpakAsset.Modules.AssignAsset.Application.GetDisposalAsset
{
    public sealed record DisposalAssetResponse
    {
        public string Id { get; set; }
        public string? Tiket { get; set; } = default!;
        public string Tipe{ get; set; }
        public string PIC { get; set; } = default!;
        public string? Grup { get; set; } = default!;
        public string? SubGrup { get; set; }
        public string? Lokasi { get; set; }
        public string Informasi { get; set; }
    }
}
