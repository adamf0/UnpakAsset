
namespace UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset
{
    public interface IDisposalAssetRepository
    {
        void Insert(DisposalAsset assignAsset);
        Task<DisposalAsset> GetAsync(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteAsync(DisposalAsset assignAsset);
    }
}
