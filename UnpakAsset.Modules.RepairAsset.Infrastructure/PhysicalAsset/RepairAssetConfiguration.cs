using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UnpakAsset.Modules.RepairAsset.Infrastructure.RepairAsset
{
    internal sealed class RepairAssetConfiguration : IEntityTypeConfiguration<Domain.RepairAsset.RepairAsset>
    {
        public void Configure(EntityTypeBuilder<Domain.RepairAsset.RepairAsset> builder)
        {
            //builder.HasOne<Category>().WithMany();
        }
    }
}
