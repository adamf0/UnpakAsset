
namespace UnpakAsset.Modules.RepairAsset.Domain.RepairAsset
{
    public interface IRepairAssetRepository
    {
        void Insert(RepairAsset assignAsset);
        Task<RepairAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteAsync(RepairAsset assignAsset);
    }
}
