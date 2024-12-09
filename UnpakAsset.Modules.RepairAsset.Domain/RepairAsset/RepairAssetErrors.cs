using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.RepairAsset.Domain.RepairAsset
{
    public static class RepairAssetErrors
    {
        public static Error EmptyData() =>
            Error.NotFound("RepairAsset.EmptyData", $"data is not found");

        public static Error NotFound(Guid Id) =>
            Error.NotFound("RepairAsset.NotFound", $"The event with the identifier {Id} was not found");

        public static readonly Error GroupNotFound = Error.Problem(
            "RepairAsset.GroupNotFound",
            "Grup tidak boleh kosong");

        public static readonly Error LocationNotFound = Error.Problem(
            "RepairAsset.LocationNotFound",
            "Lokasi tidak boleh kosong");

        public static readonly Error GroupAndLocationInvalidCategory = Error.Problem(
            "RepairAsset.GroupAndLocationInvalidCategory",
            "Pilih salah satu kategori antara Grup atau Lokasi");

        public static readonly Error GroupAndLocationNotFound = Error.Problem(
            "RepairAsset.GroupAndLocationNotFound",
            "Kategori antara Grup atau Lokasi tidak boleh kosong");

        public static Error TypeNotFound(string type) => Error.Problem(
            "RepairAsset.TypeNotFound",
            $"Tipe '{type}' tidak terdaftar di sistem ini");

        public static Error TypeIvalid(string type) => Error.Problem(
            "RepairAsset.TypeIvalid",
            $"Tipe dengan nilai '{type}' tidak sesuai dengan aturan sistem");

        public static readonly Error InformationNotFound = Error.Problem(
            "RepairAsset.InformationNotFound",
            "Informasi pindah aset tidak boleh kosong");

        public static readonly Error PICNotFound = Error.Problem(
            "RepairAsset.PICNotFound",
            "Pic pindah aset tidak boleh kosong");

        public static Error InvalidDate(string target) => Error.Problem(
            "Asset.InvalidDate",
            $"Format tanggal pada data '${target}' tidak valid");
    }
}
