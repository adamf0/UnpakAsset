namespace UnpakAsset.Modules.AssignAsset.Application.GetRepairAsset
{
    public sealed record RepairAssetResponse
    {
        public string Id { get; set; }
        public string Tipe{ get; set; }
        public string PIC { get; set; } = default!;
        public string? Grup { get; set; } = default!;
        public string? SubGrup { get; set; }
        public string? Lokasi { get; set; }
        public string Informasi { get; set; }
    }
}
