using System.ComponentModel.DataAnnotations.Schema;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.AssignAsset.Domain.AssignAsset
{
    public sealed partial class AssignAsset : Entity
    {
        private AssignAsset()
        {
        }

        [Column(TypeName = "VARCHAR(36)")]
        public Guid Id { get; private set; }
        public string? Nidn { get; private set; } = null!;
        public string? Nip { get; private set; }
        public string? Fakultas { get; private set; } = null!;
        public string? Prodi { get; private set; } = null!;
        public string? Unit { get; private set; }
        public string Barcode { get; private set; }
        [Column(TypeName = "tinyint(1)")]
        public bool IsChange { get; private set; }

        public static AssignAssetBuilder Update(AssignAsset prev) => new AssignAssetBuilder(prev);

        public static Result<AssignAsset> Create(
        string? nidn,
        string? nip,
        string? fakultas,
        string? prodi,
        string? unit,
        string barcode,
        bool isChange = false
        )
        {
            if (
                string.IsNullOrWhiteSpace(nidn) &&
                string.IsNullOrWhiteSpace(nip) &&
                string.IsNullOrWhiteSpace(fakultas) &&
                string.IsNullOrWhiteSpace(prodi) &&
                string.IsNullOrWhiteSpace(unit)
            )
            {
                return Result.Failure<AssignAsset>(AssignAssetErrors.TargetAssignNotFound);
            }

            if (
                !string.IsNullOrWhiteSpace(nidn) &&
                !string.IsNullOrWhiteSpace(nip) &&
                !string.IsNullOrWhiteSpace(fakultas) &&
                !string.IsNullOrWhiteSpace(prodi) &&
                !string.IsNullOrWhiteSpace(unit)
            )
            {
                return Result.Failure<AssignAsset>(AssignAssetErrors.RejectMultiTargetAssign);
            }

            if (string.IsNullOrWhiteSpace(barcode))
            {
                return Result.Failure<AssignAsset>(AssignAssetErrors.BarcodeNotFound);
            }

            var assignAsset = new AssignAsset
            {
                Id = Guid.NewGuid(),
                Nidn = nidn,
                Nip = nip,
                Fakultas = fakultas,
                Prodi = prodi,
                Unit = unit,
                Barcode = barcode,
                IsChange = isChange,
            };

            assignAsset.Raise(new AssignAssetCreatedDomainEvent(assignAsset.Id));

            return assignAsset;
        }
    }
}
