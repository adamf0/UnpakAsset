namespace UnpakAsset.Modules.Tag.Application.GetGroup
{
    /*public sealed record AssetResponse(
        Guid Id,
        string Nama,
        [property: Column("tanggal_terdaftar")]  DateTime TanggalTerdaftar,
        string Kondisi,
        string KodeAset,
        [property: Column("id_group")] string? Grup,
        [property: Column("id_sub_group")] string? SubGrup,
        [property: Column("id_location")] string? Lokasi,
        [property: Column("po")] string? PO,
        [property: Column("harga_unit")]  decimal HargaPerUnit,
        [property: Column("total_unit")]  int TotalUnit        
    );*/
    public sealed record GroupResponse
    {
        public string Id { get; set; }
        public string Nama { get; set; } = default!;
    }

}
