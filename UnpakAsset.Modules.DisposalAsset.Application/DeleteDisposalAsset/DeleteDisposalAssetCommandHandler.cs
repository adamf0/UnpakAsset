using UnpakAsset.Modules.DisposalAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Application.DeleteDisposalAsset
{
    internal sealed class DeleteDisposalAssetCommandHandler(
    IDisposalAssetRepository DisposalAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteDisposalAssetCommand>
    {
        public async Task<Result> Handle(DeleteDisposalAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.DisposalAsset.DisposalAsset? existingDisposalAsset = await DisposalAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingDisposalAsset is null)
            {
                return Result.Failure(DisposalAssetErrors.NotFound(request.Id));
            }

            await DisposalAssetRepository.DeleteAsync(existingDisposalAsset!);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
