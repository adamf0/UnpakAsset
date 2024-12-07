using UnpakAsset.Modules.AssignAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Domain.AssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Application.CreateAssignAsset
{
    internal sealed class CreateAssignAssetCommandHandler(
    IAssignAssetRepository assignAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAssignAssetCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateAssignAssetCommand request, CancellationToken cancellationToken)
        {
            //check barcode has assign to target [x]

            Result<Domain.AssignAsset.AssignAsset> result = Domain.AssignAsset.AssignAsset.Create(
                request.Nidn,
                request.Nip,
                request.Fakultas,
                request.Prodi,
                request.Unit,
                request.Barcode
            );

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(result.Error);
            }

            assignAssetRepository.Insert(result.Value);
            //event change table position asset [x]

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Value.Id;
        }
    }
}
