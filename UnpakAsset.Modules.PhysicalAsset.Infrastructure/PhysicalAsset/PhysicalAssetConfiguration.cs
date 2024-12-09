using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UnpakAsset.Modules.PhysicalAsset.Infrastructure.PhysicalAsset
{
    internal sealed class PhysicalAssetConfiguration : IEntityTypeConfiguration<Domain.PhysicalAsset.PhysicalAsset>
    {
        public void Configure(EntityTypeBuilder<Domain.PhysicalAsset.PhysicalAsset> builder)
        {
            //builder.HasOne<Category>().WithMany();
        }
    }
}
