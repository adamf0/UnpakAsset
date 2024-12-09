using UnpakAsset.Modules.MoveAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.MoveAsset.Domain.MoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Application.DeleteMoveAsset
{
    internal sealed class DeleteMoveAssetCommandHandler(
    IMoveAssetRepository moveAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteMoveAssetCommand>
    {
        public async Task<Result> Handle(DeleteMoveAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.MoveAsset.MoveAsset? existingMoveAsset = await moveAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingMoveAsset is null)
            {
                return Result.Failure(MoveAssetErrors.NotFound(request.Id));
            }

            await moveAssetRepository.DeleteAsync(existingMoveAsset!);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
