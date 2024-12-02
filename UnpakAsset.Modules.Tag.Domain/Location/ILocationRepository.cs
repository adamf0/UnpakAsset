namespace UnpakAsset.Modules.Tag.Domain.Location
{
    public interface ILocationRepository
    {
        void Insert(Location asset);
        Task<Location> GetAsync(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteAsync(Location asset);
    }
}
