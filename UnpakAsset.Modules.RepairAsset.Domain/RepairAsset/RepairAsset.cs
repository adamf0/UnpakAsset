using System.ComponentModel.DataAnnotations.Schema;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.RepairAsset.Domain.RepairAsset
{
    public sealed partial class RepairAsset : Entity
    {
        private RepairAsset()
        {
        }

        [Column(TypeName = "VARCHAR(36)")]
        public Guid Id { get; private set; }

        public string Tipe { get; private set; }
        public string PIC { get; private set; } = null!;
        [Column(TypeName = "VARCHAR(36)")]
        public string? Grup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? SubGrup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? Lokasi { get; private set; }
        public string Informasi { get; private set; }

        public static RepairAssetBuilder Update(RepairAsset prev) => new RepairAssetBuilder(prev);

        public static Result<RepairAsset> Create(
            string tipe,
            string pic,
            string? grup,
            string? sub_grup,
            string? lokasi,
            string informasi
        )
        {
            if (string.IsNullOrWhiteSpace(tipe))
            {
                return Result.Failure<RepairAsset>(RepairAssetErrors.TypeNotFound(tipe));
            }

            if (Array.IndexOf(new[] { TypePhysical.Group.ToEnumString(), TypePhysical.Location.ToEnumString()}, tipe) < 0)
            {
                return Result.Failure<RepairAsset>(RepairAssetErrors.TypeIvalid(tipe));
            }

            if (
                    string.IsNullOrWhiteSpace(grup) &&
                    string.IsNullOrWhiteSpace(lokasi)
                )
            {
                return Result.Failure<RepairAsset>(RepairAssetErrors.GroupAndLocationNotFound);
            }

            if (
                !string.IsNullOrWhiteSpace(grup) &&
                !string.IsNullOrWhiteSpace(lokasi)
            )
            {
                return Result.Failure<RepairAsset>(RepairAssetErrors.GroupAndLocationInvalidCategory);
            }

            if (
                    tipe == TypePhysical.Group.ToEnumString() &&
                    grup?.Length==0
                )
            {
                return Result.Failure<RepairAsset>(RepairAssetErrors.GroupNotFound);
            }

            if (
                tipe == TypePhysical.Location.ToEnumString() &&
                lokasi?.Length == 0
            )
            {
                return Result.Failure<RepairAsset>(RepairAssetErrors.LocationNotFound);
            }

            if (string.IsNullOrWhiteSpace(pic))
            {
                return Result.Failure<RepairAsset>(RepairAssetErrors.PICNotFound);
            }

            if (string.IsNullOrWhiteSpace(informasi))
            {
                return Result.Failure<RepairAsset>(RepairAssetErrors.InformationNotFound);
            }

            var assignAsset = new RepairAsset
            {
                Id = Guid.NewGuid(),
                Tipe = tipe,
                PIC = pic,
                Grup = grup,
                SubGrup = sub_grup,
                Lokasi = lokasi,
                Informasi = informasi,
            };

            assignAsset.Raise(new RepairAssetCreatedDomainEvent(assignAsset.Id));

            return assignAsset;
        }
    }
}
