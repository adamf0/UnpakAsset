
namespace UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset
{
    public interface IPhysicalAssetRepository
    {
        void Insert(PhysicalAsset assignAsset);
        Task<PhysicalAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteAsync(PhysicalAsset assignAsset);
    }
}
