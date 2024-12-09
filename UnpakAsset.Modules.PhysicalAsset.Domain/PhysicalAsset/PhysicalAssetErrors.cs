using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset
{
    public static class PhysicalAssetErrors
    {
        public static Error EmptyData() =>
            Error.NotFound("PhysicalAsset.EmptyData", $"data is not found");

        public static Error NotFound(Guid Id) =>
            Error.NotFound("PhysicalAsset.NotFound", $"The event with the identifier {Id} was not found");

        public static readonly Error GroupNotFound = Error.Problem(
            "PhysicalAsset.GroupNotFound",
            "Grup tidak boleh kosong");

        public static readonly Error LocationNotFound = Error.Problem(
            "PhysicalAsset.LocationNotFound",
            "Lokasi tidak boleh kosong");

        public static readonly Error GroupAndLocationInvalidCategory = Error.Problem(
            "PhysicalAsset.GroupAndLocationInvalidCategory",
            "Pilih salah satu kategori antara Grup atau Lokasi");

        public static readonly Error GroupAndLocationNotFound = Error.Problem(
            "PhysicalAsset.GroupAndLocationNotFound",
            "Kategori antara Grup atau Lokasi tidak boleh kosong");

        public static Error TypeNotFound(string type) => Error.Problem(
            "PhysicalAsset.TypeNotFound",
            $"Tipe '{type}' tidak terdaftar di sistem ini");

        public static Error TypeIvalid(string type) => Error.Problem(
            "PhysicalAsset.TypeIvalid",
            $"Tipe dengan nilai '{type}' tidak sesuai dengan aturan sistem");

        public static readonly Error InformationNotFound = Error.Problem(
            "PhysicalAsset.InformationNotFound",
            "Informasi pindah aset tidak boleh kosong");

        public static readonly Error PICNotFound = Error.Problem(
            "PhysicalAsset.PICNotFound",
            "Pic pindah aset tidak boleh kosong");

        public static Error InvalidDate(string target) => Error.Problem(
            "Asset.InvalidDate",
            $"Format tanggal pada data '${target}' tidak valid");
    }
}
