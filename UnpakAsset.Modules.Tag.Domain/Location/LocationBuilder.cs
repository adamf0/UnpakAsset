using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.Tag.Domain.Location
{
    public sealed partial class Location
    {
        public sealed class LocationBuilder
        {
            private readonly Location _location;
            private Result? _result;

            public LocationBuilder(Location location)
            {
                _location = location;
            }

            private bool HasError => _result is not null && _result.IsFailure;

            public Result<Location> Build()
            {
                return HasError ? Result.Failure<Location>(_result!.Error) : Result.Success(_location);
            }

            public LocationBuilder ChangeNama(string nama)
            {
                if (HasError) return this;

                if (string.IsNullOrWhiteSpace(nama))
                {
                    _result = Result.Failure<Location>(LocationErrors.NamaNotFound);
                    return this;
                }

                _location.Nama = nama;
                return this;
            }
        }
    }
}

