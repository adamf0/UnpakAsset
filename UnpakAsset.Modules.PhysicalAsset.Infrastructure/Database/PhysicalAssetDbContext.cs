using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnpakAsset.Modules.PhysicalAsset.Application.Abstractions.Data;
using UnpakAsset.Modules.PhysicalAsset.Infrastructure.PhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Infrastructure.Database
{
    public sealed class PhysicalAssetDbContext(DbContextOptions<PhysicalAssetDbContext> options) : DbContext(options), IUnitOfWork
    {
        internal DbSet<Domain.PhysicalAsset.PhysicalAsset> PhysicalAsset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Domain.PhysicalAsset.PhysicalAsset>().ToTable(Schemas.PhysicalAsset);
            modelBuilder.Entity<Domain.PhysicalAsset.PhysicalAsset>(entity =>
            {
                var guidConverter = new ValueConverter<Guid, string>(
                    v => v.ToString("D"), // Mengonversi Guid ke string dengan format "N" (tidak ada tanda hubung)
                    v => Guid.ParseExact(v, "D") // Mengonversi string kembali menjadi Guid
                );
                entity.ToTable(Schemas.PhysicalAsset);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .HasColumnType("VARCHAR(36)");
                //.HasConversion(guidConverter);

                entity.Property(e => e.Tipe)
                      .HasColumnName("type");

                entity.Property(e => e.TanggalMulai)
                      .HasColumnName("tanggal_mulai");

                entity.Property(e => e.TanggalAkhir)
                      .HasColumnName("tanggal_akhir");

                entity.Property(e => e.PIC)
                      .HasColumnName("pic");

                entity.Property(e => e.Grup)
                      .HasColumnName("id_group")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.SubGrup)
                      .HasColumnName("id_sub_group")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.Lokasi)
                      .HasColumnName("id_location")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.Informasi)
                      .HasColumnName("informasi");
            });
            modelBuilder.ApplyConfiguration(new PhysicalAssetConfiguration());
        }
    }
}
