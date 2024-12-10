using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnpakAsset.Modules.DisposalAsset.Application.Abstractions.Data;
using UnpakAsset.Modules.DisposalAsset.Infrastructure.DisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Infrastructure.Database
{
    public sealed class DisposalAssetDbContext(DbContextOptions<DisposalAssetDbContext> options) : DbContext(options), IUnitOfWork
    {
        internal DbSet<Domain.DisposalAsset.DisposalAsset> DisposalAsset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Domain.DisposalAsset.DisposalAsset>().ToTable(Schemas.DisposalAsset);
            modelBuilder.Entity<Domain.DisposalAsset.DisposalAsset>(entity =>
            {
                var guidConverter = new ValueConverter<Guid, string>(
                    v => v.ToString("D"), // Mengonversi Guid ke string dengan format "N" (tidak ada tanda hubung)
                    v => Guid.ParseExact(v, "D") // Mengonversi string kembali menjadi Guid
                );
                entity.ToTable(Schemas.DisposalAsset);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .HasColumnType("VARCHAR(36)");
                //.HasConversion(guidConverter);

                entity.Property(e => e.Tiket)
                      .HasColumnName("id_ticket");

                entity.Property(e => e.Tipe)
                      .HasColumnName("type");

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
            modelBuilder.ApplyConfiguration(new DisposalAssetConfiguration());
        }
    }
}
