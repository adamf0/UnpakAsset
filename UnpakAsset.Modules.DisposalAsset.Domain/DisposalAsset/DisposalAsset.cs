using System.ComponentModel.DataAnnotations.Schema;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset
{
    public sealed partial class DisposalAsset : Entity
    {
        private DisposalAsset()
        {
        }

        [Column(TypeName = "VARCHAR(36)")]
        public Guid Id { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? Tiket { get; private set; }
        public string Tipe { get; private set; }
        public string PIC { get; private set; } = null!;
        [Column(TypeName = "VARCHAR(36)")]
        public string? Grup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? SubGrup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? Lokasi { get; private set; }
        public string Informasi { get; private set; }

        public static DisposalAssetBuilder Update(DisposalAsset prev) => new DisposalAssetBuilder(prev);

        public static Result<DisposalAsset> Create(
            string? tiket,
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
                return Result.Failure<DisposalAsset>(DisposalAssetErrors.TypeNotFound(tipe));
            }

            if (Array.IndexOf(new[] { TypePhysical.Group.ToEnumString(), TypePhysical.Location.ToEnumString()}, tipe) < 0)
            {
                return Result.Failure<DisposalAsset>(DisposalAssetErrors.TypeIvalid(tipe));
            }

            if (
                    string.IsNullOrWhiteSpace(grup) &&
                    string.IsNullOrWhiteSpace(lokasi)
                )
            {
                return Result.Failure<DisposalAsset>(DisposalAssetErrors.GroupAndLocationNotFound);
            }

            if (
                !string.IsNullOrWhiteSpace(grup) &&
                !string.IsNullOrWhiteSpace(lokasi)
            )
            {
                return Result.Failure<DisposalAsset>(DisposalAssetErrors.GroupAndLocationInvalidCategory);
            }

            if (
                    tipe == TypePhysical.Group.ToEnumString() &&
                    grup?.Length==0
                )
            {
                return Result.Failure<DisposalAsset>(DisposalAssetErrors.GroupNotFound);
            }

            if (
                tipe == TypePhysical.Location.ToEnumString() &&
                lokasi?.Length == 0
            )
            {
                return Result.Failure<DisposalAsset>(DisposalAssetErrors.LocationNotFound);
            }

            if (string.IsNullOrWhiteSpace(pic))
            {
                return Result.Failure<DisposalAsset>(DisposalAssetErrors.PICNotFound);
            }

            if (string.IsNullOrWhiteSpace(informasi))
            {
                return Result.Failure<DisposalAsset>(DisposalAssetErrors.InformationNotFound);
            }

            var assignAsset = new DisposalAsset
            {
                Id = Guid.NewGuid(),
                Tiket = tiket,
                Tipe = tipe,
                PIC = pic,
                Grup = grup,
                SubGrup = sub_grup,
                Lokasi = lokasi,
                Informasi = informasi,
            };

            assignAsset.Raise(new DisposalAssetCreatedDomainEvent(assignAsset.Id));

            return assignAsset;
        }
    }
}
