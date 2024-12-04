using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.AssignAsset.Domain.AssignAsset;

namespace UnpakAsset.Modules.AssignAsset.Application.UpdateAssignAsset
{
    internal sealed class UpdateAssignAssetCommandHandler(
    IAssignAssetRepository assignAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateAssignAssetCommand>
    {
        public async Task<Result> Handle(UpdateAssignAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.AssignAsset.AssignAsset? existingAssignAsset = await assignAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingAssignAsset is null)
            {
                Result.Failure(AssignAssetErrors.NotFound(request.Id));
            }

            //paralel async await
            //check barcode
            //check asset disposal is not null -> throw = api [x]
            //check asset[isChange] = 1 -> throw = api [x]
            //check asset postion(last) != existing assign -> throw = api [x]

            Result<Domain.AssignAsset.AssignAsset> AssignAsset = Domain.AssignAsset.AssignAsset.Update(existingAssignAsset!)
                         .ChangeNidn(request.Nidn)
                         .ChangeNip(request.Nip)
                         .ChangeFakultas(request.Fakultas)
                         .ChangeProdi(request.Prodi)
                         .ChangeUnit(request.Unit)
                         .ChangeBarcode(request.Barcode)
                         .Build();

            if (AssignAsset.IsFailure)
            {
                return Result.Failure<Guid>(AssignAsset.Error);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
