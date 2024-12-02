using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.Asset.Domain.Asset
{
    public sealed partial class Asset : Entity
    {
        private Asset()
        {
        }

        [Column(TypeName = "VARCHAR(36)")]
        public Guid Id { get; private set; }
        public string Nama { get; private set; } = null!;
        public DateTime TanggalTerdaftar { get; private set; }
        public string Kondisi { get; private set; } = null!;
        public string KodeAsset { get; private set; } = null!;
        [Column(TypeName = "VARCHAR(36)")]
        public string? Grup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? SubGrup { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string? Lokasi { get; private set; }
        public string? PO { get; private set; }
        public decimal HargaPerUnit { get; private set; }
        public int TotalUnit { get; private set; }

        public static AssetBuilder Update(Asset prev) => new AssetBuilder(prev);

        public static Result<Asset> Create(
        string nama,
        string tanggal_terdaftar,
        string kondisi,
        string kode_aset,
        string? grup,
        string? subgrup,
        string? lokasi,
        string? po,
        string harga_perunit,
        string total_unit
        )
        {
            DateTime tanggal;
            try {
                tanggal = DateTime.Parse(tanggal_terdaftar);
            } catch (Exception e){
                return Result.Failure<Asset>(AssetErrors.TanggalTerdaftarInvalidDate);
            }


            if (Array.IndexOf(new[] { KondisiAsset.Baru.ToEnumString(), KondisiAsset.Bekas.ToEnumString() }, kondisi) < 0)
            {
                return Result.Failure<Asset>(AssetErrors.ConditionInvalidType(kondisi));
            }

            if (
                (grup == null || grup.Length == 0) &&
                (lokasi == null || lokasi.Length == 0)
            )
            {
                return Result.Failure<Asset>(AssetErrors.CategoryNotFound);
            }

            if (string.IsNullOrWhiteSpace(po))
            {
                return Result.Failure<Asset>(AssetErrors.PONotFound);
            }

            var asset = new Asset
            {
                Id = Guid.NewGuid(),
                Nama = nama,
                TanggalTerdaftar = tanggal,
                Kondisi = kondisi,
                KodeAsset = kode_aset,
                Grup = grup,
                SubGrup = subgrup,
                Lokasi = lokasi,
                PO = po,
                HargaPerUnit = Decimal.Parse(harga_perunit),
                TotalUnit = int.Parse(total_unit),
            };

            asset.Raise(new AssetCreatedDomainEvent(asset.Id));

            return asset;
        }
    }
}

