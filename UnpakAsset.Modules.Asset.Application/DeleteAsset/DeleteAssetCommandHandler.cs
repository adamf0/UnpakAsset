using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Modules.Asset.Domain.Asset;

namespace UnpakAsset.Modules.Asset.Application.DeleteAsset
{
    internal sealed class DeleteAssetCommandHandler(
    IAssetRepository assetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteAssetCommand>
    {
        public async Task<Result> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.Asset.Asset? existingAsset = await assetRepository.GetAsync(request.Id, cancellationToken);

            if (existingAsset is null)
            {
                return Result.Failure(AssetErrors.NotFound(request.Id));
            }

            await assetRepository.DeleteAsync(existingAsset!);
            //event update change table position asset, order desc + select first

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
