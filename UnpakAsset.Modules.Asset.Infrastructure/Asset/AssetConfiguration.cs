using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UnpakAsset.Modules.Asset.Infrastructure.Asset
{
    internal sealed class AssetConfiguration : IEntityTypeConfiguration<Domain.Asset.Asset>
    {
        public void Configure(EntityTypeBuilder<Domain.Asset.Asset> builder)
        {
            //builder.HasOne<Category>().WithMany();
        }
    }
}
