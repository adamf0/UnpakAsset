using UnpakAsset.Modules.RepairAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.RepairAsset.Domain.RepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Application.DeleteRepairAsset
{
    internal sealed class DeleteRepairAssetCommandHandler(
    IRepairAssetRepository RepairAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteRepairAssetCommand>
    {
        public async Task<Result> Handle(DeleteRepairAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.RepairAsset.RepairAsset? existingRepairAsset = await RepairAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingRepairAsset is null)
            {
                return Result.Failure(RepairAssetErrors.NotFound(request.Id));
            }

            await RepairAssetRepository.DeleteAsync(existingRepairAsset!);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
