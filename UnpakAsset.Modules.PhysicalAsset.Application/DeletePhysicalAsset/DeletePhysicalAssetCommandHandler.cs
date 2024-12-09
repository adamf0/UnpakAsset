using UnpakAsset.Modules.PhysicalAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Application.DeletePhysicalAsset
{
    internal sealed class DeletePhysicalAssetCommandHandler(
    IPhysicalAssetRepository physicalAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeletePhysicalAssetCommand>
    {
        public async Task<Result> Handle(DeletePhysicalAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.PhysicalAsset.PhysicalAsset? existingPhysicalAsset = await physicalAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingPhysicalAsset is null)
            {
                return Result.Failure(PhysicalAssetErrors.NotFound(request.Id));
            }

            await physicalAssetRepository.DeleteAsync(existingPhysicalAsset!);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
