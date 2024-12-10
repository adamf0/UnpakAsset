using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UnpakAsset.Modules.DisposalAsset.Infrastructure.DisposalAsset
{
    internal sealed class DisposalAssetConfiguration : IEntityTypeConfiguration<Domain.DisposalAsset.DisposalAsset>
    {
        public void Configure(EntityTypeBuilder<Domain.DisposalAsset.DisposalAsset> builder)
        {
            //builder.HasOne<Category>().WithMany();
        }
    }
}
