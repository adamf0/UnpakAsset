using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset
{
    public static class DisposalAssetErrors
    {
        public static Error EmptyData() =>
            Error.NotFound("DisposalAsset.EmptyData", $"data is not found");

        public static Error NotFound(Guid Id) =>
            Error.NotFound("DisposalAsset.NotFound", $"The event with the identifier {Id} was not found");

        public static readonly Error GroupNotFound = Error.Problem(
            "DisposalAsset.GroupNotFound",
            "Grup tidak boleh kosong");

        public static readonly Error LocationNotFound = Error.Problem(
            "DisposalAsset.LocationNotFound",
            "Lokasi tidak boleh kosong");

        public static readonly Error GroupAndLocationInvalidCategory = Error.Problem(
            "DisposalAsset.GroupAndLocationInvalidCategory",
            "Pilih salah satu kategori antara Grup atau Lokasi");

        public static readonly Error GroupAndLocationNotFound = Error.Problem(
            "DisposalAsset.GroupAndLocationNotFound",
            "Kategori antara Grup atau Lokasi tidak boleh kosong");

        public static Error TypeNotFound(string type) => Error.Problem(
            "DisposalAsset.TypeNotFound",
            $"Tipe '{type}' tidak terdaftar di sistem ini");

        public static Error TypeIvalid(string type) => Error.Problem(
            "DisposalAsset.TypeIvalid",
            $"Tipe dengan nilai '{type}' tidak sesuai dengan aturan sistem");

        public static readonly Error InformationNotFound = Error.Problem(
            "DisposalAsset.InformationNotFound",
            "Informasi pindah aset tidak boleh kosong");

        public static readonly Error PICNotFound = Error.Problem(
            "DisposalAsset.PICNotFound",
            "Pic pindah aset tidak boleh kosong");
    }
}
