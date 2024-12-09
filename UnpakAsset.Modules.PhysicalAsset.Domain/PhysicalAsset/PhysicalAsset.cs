using System.ComponentModel.DataAnnotations.Schema;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset
{
    public sealed partial class PhysicalAsset : Entity
    {
        private PhysicalAsset()
        {
        }

        [Column(TypeName = "VARCHAR(36)")]
        public Guid Id { get; private set; }

        public string Tipe { get; private set; }
        public DateTime TanggalMulai { get; private set; }
        public DateTime TanggalAkhir { get; private set; }
        public string PIC { get; private set; } = null!;
        [Column(TypeName = "VARCHAR(36)")]
        public string? Grup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? SubGrup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? Lokasi { get; private set; }
        public string Informasi { get; private set; }

        public static PhysicalAssetBuilder Update(PhysicalAsset prev) => new PhysicalAssetBuilder(prev);

        public static Result<PhysicalAsset> Create(
            string tipe,
            string tanggal_mulai,
            string tanggal_akhir,
            string pic,
            string? grup,
            string? sub_grup,
            string? lokasi,
            string informasi
        )
        {
            if (string.IsNullOrWhiteSpace(tipe))
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.TypeNotFound(tipe));
            }

            if (Array.IndexOf(new[] { TypePhysical.Group.ToEnumString(), TypePhysical.Location.ToEnumString()}, tipe) < 0)
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.TypeIvalid(tipe));
            }

            DateTime _tanggal_mulai;
            try
            {
                _tanggal_mulai = DateTime.Parse(tanggal_mulai);
            }
            catch (Exception e)
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.InvalidDate("tanggal mulai"));
            }

            DateTime _tanggal_akhir;
            try
            {
                _tanggal_akhir = DateTime.Parse(tanggal_akhir);
            }
            catch (Exception e)
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.InvalidDate("tanggal akhir"));
            }


            if (
                    !string.IsNullOrWhiteSpace(grup) &&
                    !string.IsNullOrWhiteSpace(lokasi)
                )
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.GroupAndLocationNotFound);
            }

            if (
                !string.IsNullOrWhiteSpace(grup) &&
                !string.IsNullOrWhiteSpace(lokasi)
            )
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.GroupAndLocationInvalidCategory);
            }

            if (
                    tipe == TypePhysical.Group.ToEnumString() &&
                    grup?.Length==0
                )
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.GroupNotFound);
            }

            if (
                tipe == TypePhysical.Location.ToEnumString() &&
                lokasi?.Length == 0
            )
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.LocationNotFound);
            }

            if (string.IsNullOrWhiteSpace(pic))
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.PICNotFound);
            }

            if (string.IsNullOrWhiteSpace(informasi))
            {
                return Result.Failure<PhysicalAsset>(PhysicalAssetErrors.InformationNotFound);
            }

            var assignAsset = new PhysicalAsset
            {
                Id = Guid.NewGuid(),
                Tipe = tipe,
                TanggalMulai = _tanggal_mulai,
                TanggalAkhir = _tanggal_akhir,
                PIC = pic,
                Grup = grup,
                SubGrup = sub_grup,
                Lokasi = lokasi,
                Informasi = informasi,
            };

            assignAsset.Raise(new PhysicalAssetCreatedDomainEvent(assignAsset.Id));

            return assignAsset;
        }
    }
}
