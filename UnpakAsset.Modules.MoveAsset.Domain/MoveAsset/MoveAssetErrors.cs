using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.MoveAsset.Domain.MoveAsset
{
    public static class MoveAssetErrors
    {
        public static Error EmptyData() =>
            Error.NotFound("MoveAsset.EmptyData", $"data is not found");

        public static Error NotFound(Guid Id) =>
            Error.NotFound("MoveAsset.NotFound", $"The event with the identifier {Id} was not found");

        public static readonly Error GroupNotFound = Error.Problem(
            "MoveAsset.GroupNotFound",
            "Grup tidak boleh kosong");

        public static readonly Error LocationNotFound = Error.Problem(
            "MoveAsset.LocationNotFound",
            "Lokasi tidak boleh kosong");

        public static readonly Error GroupAndLocationInvalidCategory = Error.Problem(
            "MoveAsset.GroupAndLocationInvalidCategory",
            "Pilih salah satu kategori antara Grup atau Lokasi");

        public static readonly Error GroupAndLocationNotFound = Error.Problem(
            "MoveAsset.GroupAndLocationNotFound",
            "Kategori antara Grup atau Lokasi tidak boleh kosong");


        public static readonly Error GroupDestinationNotFound = Error.Problem(
           "MoveAsset.GroupDestinationNotFound",
           "Grup target tidak boleh kosong");

        public static readonly Error LocationDestinationNotFound = Error.Problem(
            "MoveAsset.LocationDestinationNotFound",
            "Lokasi target tidak boleh kosong");

        public static readonly Error GroupAndLocationDestinationInvalidCategory = Error.Problem(
            "MoveAsset.GroupAndLocationDestinationInvalidCategory",
            "Pilih salah satu kategori antara Grup atau Lokasi tujuan");

        public static readonly Error GroupAndLocationDestinationNotFound = Error.Problem(
            "MoveAsset.GroupAndLocationDestinationNotFound",
            "Kategori antara Grup atau Lokasi tujuan tidak boleh kosong");

        public static Error TypeNotFound(string type) => Error.Problem(
            "MoveAsset.TypeNotFound",
            $"Tipe '{type}' tidak terdaftar di sistem ini");

        public static Error TypeIvalid(string type) => Error.Problem(
            "MoveAsset.TypeIvalid",
            $"Tipe dengan nilai '{type}' tidak sesuai dengan aturan sistem");

        public static readonly Error InformationNotFound = Error.Problem(
            "MoveAsset.InformationNotFound",
            "Informasi pindah aset tidak boleh kosong");

        public static readonly Error PICNotFound = Error.Problem(
            "MoveAsset.PICNotFound",
            "Pic pindah aset tidak boleh kosong");

        public static readonly Error AvailableTypeOnTicket = Error.Problem(
            "MoveAsset.AvailableTypeOnTicket",
            "Selain grup & lokasi tidak diizinkan");

        public static readonly Error TargetUserNotFound = Error.Problem(
            "MoveAsset.TargetUserNotFound",
            "target user tidak boleh kosong");
    }
}
