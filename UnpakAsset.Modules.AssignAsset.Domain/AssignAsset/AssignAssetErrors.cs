using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.AssignAsset.Domain.AssignAsset
{
    public static class AssignAssetErrors
    {
        public static Error EmptyData() =>
            Error.NotFound("AssignAsset.EmptyData", $"data is not found");

        public static Error NotFound(Guid Id) =>
            Error.NotFound("AssignAsset.NotFound", $"The event with the identifier {Id} was not found");

        public static readonly Error TargetAssignNotFound = Error.Problem(
            "AssignAsset.TargetAssignNotFound",
            "Asset belum diatur kepemilikannya");

        public static readonly Error RejectMultiTargetAssign = Error.Problem(
            "AssignAsset.RejectMultiTargetAssign",
            "NIDN, NIP dan Department harus salah satu diisi");

        public static readonly Error BarcodeNotFound = Error.Problem(
            "AssignAsset.BarcodeNotFound",
            "Barcode tidak ditemukan");

        public static Error TargetAssignNotInPosition(string Barcode) => Error.Problem(
            "AssignAsset.TargetAssignNotInPosition",
            $"Asset dengan barcode '{Barcode}' tidak berada dalam lokasi sebelumnya");

    }
}
