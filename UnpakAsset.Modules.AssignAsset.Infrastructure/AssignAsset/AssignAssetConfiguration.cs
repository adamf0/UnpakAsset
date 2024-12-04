using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UnpakAsset.Modules.AssignAsset.Infrastructure.AssignAsset
{
    internal sealed class AssignAssetConfiguration : IEntityTypeConfiguration<Domain.AssignAsset.AssignAsset>
    {
        public void Configure(EntityTypeBuilder<Domain.AssignAsset.AssignAsset> builder)
        {
            //builder.HasOne<Category>().WithMany();
        }
    }
}
