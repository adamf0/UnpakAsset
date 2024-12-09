using System.ComponentModel.DataAnnotations.Schema;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.MoveAsset.Domain.MoveAsset
{
    public sealed partial class MoveAsset : Entity
    {
        private MoveAsset()
        {
        }

        [Column(TypeName = "VARCHAR(36)")]
        public Guid Id { get; private set; }
        public string? Tiket { get; private set; } = null!;
        public string Tipe { get; private set; }
        public string PIC { get; private set; } = null!;
        [Column(TypeName = "VARCHAR(36)")]
        public string? Grup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? SubGrup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? Lokasi { get; private set; }


        [Column(TypeName = "VARCHAR(36)")]
        public string? GrupTarget { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? SubGrupTarget { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]

        public string? UserTarget { get; private set; }
        public string? LokasiTarget { get; private set; }
        public string Informasi { get; private set; }
        
        public static MoveAssetBuilder Update(MoveAsset prev) => new MoveAssetBuilder(prev);

        public static Result<MoveAsset> Create(
            string? tiket,
            string tipe,
            string pic,
            string? grup,
            string? sub_grup,
            string? lokasi,
            string? grup_target,
            string? sub_grup_target,
            string? lokasi_target,
            string? user_target,
            string informasi
        )
        {
            if (string.IsNullOrWhiteSpace(tipe))
            {
                return Result.Failure<MoveAsset>(MoveAssetErrors.TypeNotFound(tipe));
            }

            if (Array.IndexOf(new[] { TypeMove.Group.ToEnumString(), TypeMove.Location.ToEnumString(), TypeMove.Personal.ToEnumString() }, tipe) < 0)
            {
                return Result.Failure<MoveAsset>(MoveAssetErrors.TypeIvalid(tipe));
            }

            if (tiket != null)
            {
                if (Array.IndexOf(new[] { TypeMove.Group.ToEnumString(), TypeMove.Location.ToEnumString() }, tipe) < 0)
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.AvailableTypeOnTicket);
                }

                if (
                    (grup == null || grup.Length == 0) &&
                    (lokasi == null || lokasi.Length == 0)
                )
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.GroupAndLocationNotFound);
                }

                if (
                    tipe == TypeMove.Group.ToEnumString() &&
                    (grup?.Length > 0)
                )
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.GroupNotFound);
                }

                if (
                    tipe == TypeMove.Location.ToEnumString() &&
                    (lokasi?.Length > 0)
                )
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.LocationNotFound);
                }

                if (
                    (grup == null || grup.Length > 0) &&
                    (lokasi == null || lokasi.Length > 0)
                )
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.GroupAndLocationInvalidCategory);
                }

                if (
                    (grup_target == null || grup_target.Length == 0) &&
                    (lokasi_target == null || lokasi_target.Length == 0)
                )
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.GroupAndLocationDestinationNotFound);
                }

                if (
                    (grup_target == null || grup_target.Length > 0) &&
                    (lokasi_target == null || lokasi_target.Length > 0)
                )
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.GroupAndLocationDestinationInvalidCategory);
                }

                if (
                    tipe == TypeMove.Group.ToEnumString() &&
                    (grup_target.Length > 0)
                )
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.GroupDestinationNotFound);
                }

                if (
                    tipe == TypeMove.Location.ToEnumString() &&
                    (lokasi_target.Length > 0)
                )
                {
                    return Result.Failure<MoveAsset>(MoveAssetErrors.LocationDestinationNotFound);
                }
            }
            else if(tipe==TypeMove.Personal.ToEnumString() && string.IsNullOrWhiteSpace(user_target))
            {
                return Result.Failure<MoveAsset>(MoveAssetErrors.TargetUserNotFound);
            }

            if (string.IsNullOrWhiteSpace(pic))
            {
                return Result.Failure<MoveAsset>(MoveAssetErrors.PICNotFound);
            }

            if (string.IsNullOrWhiteSpace(informasi))
            {
                return Result.Failure<MoveAsset>(MoveAssetErrors.InformationNotFound);
            }

            var assignAsset = new MoveAsset
            {
                Id = Guid.NewGuid(),
                Tiket = tiket,
                Tipe = tipe,
                PIC = pic,
                Grup = grup,
                SubGrup = sub_grup,
                GrupTarget = grup_target,
                SubGrupTarget = grup_target,
                LokasiTarget = lokasi_target,
                UserTarget  = user_target,
                Lokasi = lokasi,
                Informasi = informasi,
            };

            assignAsset.Raise(new MoveAssetCreatedDomainEvent(assignAsset.Id));

            return assignAsset;
        }
    }
}
