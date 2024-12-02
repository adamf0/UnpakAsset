using System.ComponentModel.DataAnnotations.Schema;
using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.Tag.Domain.Location
{
    public sealed partial class Location : Entity
    {
        private Location()
        {
        }

        [Column(TypeName = "VARCHAR(36)")]
        public Guid Id { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string Nama { get; private set; } = null!;
        public static LocationBuilder Update(Location prev) => new LocationBuilder(prev);

        public static Result<Location> Create(
        string nama
        )
        {
            if (string.IsNullOrWhiteSpace(nama))
            {
                return Result.Failure<Location>(LocationErrors.NamaNotFound);
            }

            var location = new Location
            {
                Id = Guid.NewGuid(),
                Nama = nama,
            };

            location.Raise(new LocationCreatedDomainEvent(location.Id));

            return location;
        }
    }
}

