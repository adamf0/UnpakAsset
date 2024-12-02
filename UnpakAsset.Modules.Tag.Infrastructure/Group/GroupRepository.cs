using Microsoft.EntityFrameworkCore;
using UnpakAsset.Modules.Tag.Domain.Group;
using UnpakAsset.Modules.Tag.Infrastructure.Database;

namespace UnpakAsset.Modules.Tag.Infrastructure.Group
{
    internal sealed class GroupRepository(TagDbContext context) : IGroupRepository
    {
        public async Task<Domain.Group.Group> GetAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            Domain.Group.Group group = await context.Group.SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);
            return group;
        }

        public async Task DeleteAsync(Domain.Group.Group group)
        {
            context.Group.Remove(group);
        }

        public void Insert(Domain.Group.Group group)
        {
            context.Group.Add(group);
        }
    }
}
