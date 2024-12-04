namespace UnpakAsset.Modules.AssignAsset.Application.GetAssignAsset
{
    public sealed record AssignAssetResponse
    {
        public string Id { get; set; }
        public string? Nidn { get; set; } = default!;
        public string? Nip{ get; set; }
        public string? Fakultas { get; set; } = default!;
        public string? Prodi { get; set; } = default!;
        public string? Unit { get; set; }
        public string Barcode { get; set; }
    }
}
