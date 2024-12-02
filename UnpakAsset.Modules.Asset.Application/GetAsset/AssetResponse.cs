using System.ComponentModel.DataAnnotations.Schema;

namespace UnpakAsset.Modules.Asset.Application.GetAsset
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
    public sealed record AssetResponse
    {
        public string Id { get; set; }
        public string Nama { get; set; } = default!;
        public DateTime TanggalTerdaftar { get; set; }
        public string Kondisi { get; set; } = default!;
        public string KodeAset { get; set; } = default!;
        public string? Grup { get; set; }
        public string? SubGrup { get; set; }
        public string? Lokasi { get; set; }
        public string? PO { get; set; }
        public decimal HargaPerUnit { get; set; }
        public int TotalUnit { get; set; }
    }

}
