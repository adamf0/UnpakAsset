using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.Asset.Domain.Asset
{
    public static class AssetErrors
    {
        public static Error EmptyData() =>
            Error.NotFound("Asset.EmptyData", $"data is not found");

        public static Error NotFound(Guid Id) =>
            Error.NotFound("Asset.NotFound", $"The event with the identifier {Id} was not found");

        public static readonly Error GroupAndLocationInvalidCategory = Error.Problem(
            "Asset.GroupAndLocationInvalidCategory",
            "Pilih salah satu kategori antara Grup atau Lokasi");

        public static readonly Error GroupAndLocationNotFound = Error.Problem(
            "Asset.GroupAndLocationNotFound",
            "Kkategori antara Grup atau Lokasi tidak boleh kosong");

        public static readonly Error TanggalTerdaftarInvalidDate = Error.Problem(
            "Asset.TanggalTerdaftarInvalidDate",
            "Format tanggal pada data 'tanggal terdaftar' tidak valid");

        public static readonly Error TotalUnitInvalidNumber = Error.Problem(
            "Asset.TotalUnitInvalidNumber",
            "Total unit tidak bisa dibawah 0");

        public static readonly Error HargaPerUnitInvalidNumber = Error.Problem(
            "Asset.HargaPerUnitInvalidNumber",
            "Harga per unit harus lebih dari 0");

        public static readonly Error PONotFound = Error.Problem(
            "Asset.PONotFound",
            "Harus ada nomor PO");

        public static readonly Error KodeAsetNotFound = Error.Problem(
            "Asset.KodeAsetNotFound",
            "Kode aset tidak ditemukan");

        public static readonly Error NamaNotFound = Error.Problem(
            "Asset.NamaNotFound",
            "Nama aset tidak ditemukan");

        public static Error ConditionInvalidType(string kondisi) => Error.Problem(
            "Asset.ConditionInvalidType",
            $"Kondisi dengan nilai '{kondisi}' tidak sesuai dengan aturan sistem");

        public static readonly Error CategoryNotFound =
            Error.NotFound("Asset.CategoryNotFound", $"Grup / lokasi harus diisi salah satu");

        public static Error GroupNotFound(string value) =>
            Error.NotFound("Asset.GroupNotFound", $"Group {value} tidak ditemukan");

        public static Error SubGroupNotFound(string value) =>
            Error.NotFound("Asset.SubGroupNotFound", $"Subgroup {value} tidak ditemukan");

        public static Error LocationNotFound(string value) =>
            Error.NotFound("Asset.LocationNotFound", $"Location {value} tidak ditemukan");
    }
}
