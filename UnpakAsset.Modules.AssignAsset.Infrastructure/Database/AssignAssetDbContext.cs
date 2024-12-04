using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Modules.AssignAsset.Infrastructure.AssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Infrastructure.Database
{
    public sealed class AssignAssetDbContext(DbContextOptions<AssignAssetDbContext> options) : DbContext(options), IUnitOfWork
    {
        internal DbSet<Domain.AssignAsset.AssignAsset> AssignAsset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Domain.AssignAsset.AssignAsset>().ToTable(Schemas.AssignAsset);
            modelBuilder.Entity<Domain.AssignAsset.AssignAsset>(entity =>
            {
                var guidConverter = new ValueConverter<Guid, string>(
                    v => v.ToString("D"), // Mengonversi Guid ke string dengan format "N" (tidak ada tanda hubung)
                    v => Guid.ParseExact(v, "D") // Mengonversi string kembali menjadi Guid
                );
                entity.ToTable(Schemas.AssignAsset);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .HasColumnType("VARCHAR(36)");
                //.HasConversion(guidConverter);

                entity.Property(e => e.Nidn)
                      .HasColumnName("nidn");

                entity.Property(e => e.Nip)
                      .HasColumnName("nip");

                entity.Property(e => e.Fakultas)
                      .HasColumnName("kode_fakultas");

                entity.Property(e => e.Prodi)
                      .HasColumnName("kode_prodi");

                entity.Property(e => e.Unit)
                      .HasColumnName("kode_unit");

                entity.Property(e => e.Barcode)
                      .HasColumnName("id_asset_barcode");

                entity.Property(e => e.IsChange)
                      .HasColumnName("isChange")
                      .HasColumnType("tinyint(1)");
            });
            modelBuilder.ApplyConfiguration(new AssignAssetConfiguration());
        }
    }
}
