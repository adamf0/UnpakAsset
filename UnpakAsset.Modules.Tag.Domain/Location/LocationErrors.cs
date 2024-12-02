using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.Tag.Domain.Location
{
    public static class LocationErrors
    {
        public static Error EmptyData() =>
            Error.NotFound("Asset.EmptyData", $"data is not found");

        public static Error NotFound(Guid Id) =>
            Error.NotFound("Asset.NotFound", $"The event with the identifier {Id} was not found");

        public static readonly Error NamaNotFound = Error.Problem(
            "Asset.NamaNotFound",
            "Nama lokasi tidak ditemukan");

    }
}
