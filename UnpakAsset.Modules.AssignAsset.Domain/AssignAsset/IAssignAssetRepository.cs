
namespace UnpakAsset.Modules.AssignAsset.Domain.AssignAsset
{
    public interface IAssignAssetRepository
    {
        void Insert(AssignAsset assignAsset);
        Task<AssignAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteAsync(AssignAsset assignAsset);
    }
}
