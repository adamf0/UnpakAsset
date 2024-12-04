using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UnpakAsset.Modules.MoveAsset.Infrastructure.MoveAsset
{
    internal sealed class MoveAssetConfiguration : IEntityTypeConfiguration<Domain.MoveAsset.MoveAsset>
    {
        public void Configure(EntityTypeBuilder<Domain.MoveAsset.MoveAsset> builder)
        {
            //builder.HasOne<Category>().WithMany();
        }
    }
}
