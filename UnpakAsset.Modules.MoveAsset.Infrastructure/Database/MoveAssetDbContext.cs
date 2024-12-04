using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Modules.MoveAsset.Infrastructure.MoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Infrastructure.Database
{
    public sealed class MoveAssetDbContext(DbContextOptions<MoveAssetDbContext> options) : DbContext(options), IUnitOfWork
    {
        internal DbSet<Domain.MoveAsset.MoveAsset> MoveAsset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Domain.MoveAsset.MoveAsset>().ToTable(Schemas.MoveAsset);
            modelBuilder.Entity<Domain.MoveAsset.MoveAsset>(entity =>
            {
                var guidConverter = new ValueConverter<Guid, string>(
                    v => v.ToString("D"), // Mengonversi Guid ke string dengan format "N" (tidak ada tanda hubung)
                    v => Guid.ParseExact(v, "D") // Mengonversi string kembali menjadi Guid
                );
                entity.ToTable(Schemas.MoveAsset);

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

                entity.Property(e => e.GrupTarget)
                      .HasColumnName("id_group_target")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.SubGrupTarget)
                      .HasColumnName("id_sub_group_target")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.LokasiTarget)
                      .HasColumnName("id_location_target")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.UserTarget)
                      .HasColumnName("id_user_target")
                      .HasColumnType("VARCHAR(36)");

                entity.Property(e => e.Informasi)
                      .HasColumnName("informasi");
            });
            modelBuilder.ApplyConfiguration(new MoveAssetConfiguration());
        }
    }
}
