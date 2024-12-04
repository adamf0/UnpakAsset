using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnpakAsset.Modules.Asset.Infrastructure.Asset;
using UnpakAsset.Common.Application.Abstractions.Data;

namespace UnpakAsset.Modules.Asset.Infrastructure.Database
{
    public sealed class AssetDbContext(DbContextOptions<AssetDbContext> options) : DbContext(options), IUnitOfWork
    {
        internal DbSet<Domain.Asset.Asset> Asset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Asset.Asset>().ToTable(Schemas.Asset);
            modelBuilder.ApplyConfiguration(new AssetConfiguration());

            modelBuilder.Entity<Domain.Asset.Asset>(entity =>
            {
                var guidConverter = new ValueConverter<Guid, string>(
                    v => v.ToString("D"), // Mengonversi Guid ke string dengan format "N" (tidak ada tanda hubung)
                    v => Guid.ParseExact(v, "D") // Mengonversi string kembali menjadi Guid
                );
                entity.ToTable(Schemas.Asset);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .HasColumnType("VARCHAR(36)");
                      //.HasConversion(guidConverter);

                entity.Property(e => e.Nama)
                      .HasColumnName("nama");

                entity.Property(e => e.TanggalTerdaftar)
                      .HasColumnName("tanggal_terdaftar");

                entity.Property(e => e.KodeAsset)
                      .HasColumnName("kode_aset");

                entity.Property(e => e.Grup)
                      .HasColumnName("id_group")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.SubGrup)
                      .HasColumnName("id_sub_group")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.Lokasi)
                      .HasColumnName("id_location")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.PO)
                      .HasColumnName("po");

                entity.Property(e => e.HargaPerUnit)
                      .HasColumnName("harga_per_unit");

                entity.Property(e => e.TotalUnit)
                      .HasColumnName("total_unit");
            });
        }
    }

}
