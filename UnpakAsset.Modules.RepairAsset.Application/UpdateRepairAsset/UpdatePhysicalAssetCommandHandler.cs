using UnpakAsset.Modules.RepairAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.RepairAsset.Domain.RepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Application.UpdateRepairAsset
{
    internal sealed class UpdateRepairAssetCommandHandler(
    IRepairAssetRepository assignAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateRepairAssetCommand>
    {
        public async Task<Result> Handle(UpdateRepairAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.RepairAsset.RepairAsset? existingRepairAsset = await assignAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingRepairAsset is null)
            {
                Result.Failure(RepairAssetErrors.NotFound(request.Id));
            }

            //paralel async await
            //check barcode
            //check asset disposal is not null -> throw = api [x]
            
            Result<Domain.RepairAsset.RepairAsset> RepairAsset = Domain.RepairAsset.RepairAsset.Update(existingRepairAsset!)
                         .ChangeType(request.Tipe)
                         .ChangePIC(request.PIC)
                         .ChangeGroup(request.Grup,null)
                         .ChangeSubGroup(request.SubGrup,null)
                         .ChangeLocation(request.Lokasi,null)
                         .ChangeInformation(request.Informasi)
                         .Build();

            if (RepairAsset.IsFailure)
            {
                return Result.Failure<Guid>(RepairAsset.Error);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
