namespace UnpakAsset.Modules.AssignAsset.Application.GetPhysicalAsset
{
    public sealed record PhysicalAssetResponse
    {
        public string Id { get; set; }
        public string Tipe{ get; set; }
        public string TanggalMulai { get; set; }
        public string TanggalAkhir { get; set; }
        public string PIC { get; set; } = default!;
        public string? Grup { get; set; } = default!;
        public string? SubGrup { get; set; }
        public string? Lokasi { get; set; }
        public string Informasi { get; set; }
    }
}
