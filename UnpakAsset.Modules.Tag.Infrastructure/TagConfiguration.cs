using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UnpakAsset.Modules.Tag.Infrastructure
{
    internal sealed class TagConfiguration : IEntityTypeConfiguration<Domain.Group.Group>
    {
        public void Configure(EntityTypeBuilder<Domain.Group.Group> builder)
        {
            //builder.HasOne<Category>().WithMany();
        }
    }
}
