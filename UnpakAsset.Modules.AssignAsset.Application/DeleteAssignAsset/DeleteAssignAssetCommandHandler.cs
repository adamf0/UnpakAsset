using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Domain.AssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Application.DeleteAssignAsset
{
    internal sealed class DeleteAssignAssetCommandHandler(
    IAssignAssetRepository assignAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteAssignAssetCommand>
    {
        public async Task<Result> Handle(DeleteAssignAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.AssignAsset.AssignAsset? existingAssignAsset = await assignAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingAssignAsset is null)
            {
                return Result.Failure(AssignAssetErrors.NotFound(request.Id));
            }

            await assignAssetRepository.DeleteAsync(existingAssignAsset!);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
