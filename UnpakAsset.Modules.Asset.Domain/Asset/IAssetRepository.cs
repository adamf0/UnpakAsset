namespace UnpakAsset.Modules.Asset.Domain.Asset
{
    public interface IAssetRepository
    {
        void Insert(Asset asset);
        Task<Asset> GetAsync(Guid Id, CancellationToken cancellationToken = default);
        Task DeleteAsync(Asset asset);
    }
}
