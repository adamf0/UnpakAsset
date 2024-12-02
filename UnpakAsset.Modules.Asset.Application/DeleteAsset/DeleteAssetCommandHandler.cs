using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Modules.Asset.Domain.Asset;

namespace UnpakAsset.Modules.Asset.Application.DeleteAsset
{
    internal sealed class DeleteAssetCommandHandler(
    IAssetRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteAssetCommand>
    {
        public async Task<Result> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.Asset.Asset? existingAsset = await userRepository.GetAsync(request.Id, cancellationToken);

            if (existingAsset is null)
            {
                return Result.Failure(AssetErrors.NotFound(request.Id));
            }

            await userRepository.DeleteAsync(existingAsset!);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
