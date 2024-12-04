
namespace UnpakAsset.Modules.MoveAsset.Domain.MoveAsset
{
    public interface IMoveAssetRepository
    {
        void Insert(MoveAsset assignAsset);
        Task<MoveAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteAsync(MoveAsset assignAsset);
    }
}
