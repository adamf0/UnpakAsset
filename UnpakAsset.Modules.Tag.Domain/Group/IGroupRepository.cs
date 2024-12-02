namespace UnpakAsset.Modules.Tag.Domain.Group
{
    public interface IGroupRepository
    {
        void Insert(Group asset);
        Task<Group> GetAsync(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteAsync(Group asset);
    }
}
