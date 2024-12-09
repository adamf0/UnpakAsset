namespace UnpakAsset.Modules.MoveAsset.Application.GetMoveAsset
{
    public sealed record MoveAssetResponse
    {
        public string Id { get; set; }
        public string? Tiket { get; set; } = default!;
        public string Tipe{ get; set; }
        public string PIC { get; set; } = default!;
        public string? Grup { get; set; } = default!;
        public string? SubGrup { get; set; }
        public string? Lokasi { get; set; }
        public string? GrupTarget { get; set; } = default!;
        public string? SubGrupTarget { get; set; }
        public string? LokasiTarget { get; set; }
        public string? UserTarget { get; set; }
        public string Informasi { get; set; }
    }
}
