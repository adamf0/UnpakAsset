using UnpakAsset.Modules.PhysicalAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Application.UpdatePhysicalAsset
{
    internal sealed class UpdatePhysicalAssetCommandHandler(
    IPhysicalAssetRepository assignAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdatePhysicalAssetCommand>
    {
        public async Task<Result> Handle(UpdatePhysicalAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.PhysicalAsset.PhysicalAsset? existingPhysicalAsset = await assignAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingPhysicalAsset is null)
            {
                Result.Failure(PhysicalAssetErrors.NotFound(request.Id));
            }

            //paralel async await
            //check barcode
            //check asset disposal is not null -> throw = api [x]
            
            Result<Domain.PhysicalAsset.PhysicalAsset> PhysicalAsset = Domain.PhysicalAsset.PhysicalAsset.Update(existingPhysicalAsset!)
                         .ChangeType(request.Tipe)
                         .ChangeTanggalMulai(request.TanggalMulai)
                         .ChangeTanggalAkhir(request.TanggalAkhir)
                         .ChangePIC(request.PIC)
                         .ChangeGroup(request.Grup,null)
                         .ChangeSubGroup(request.SubGrup,null)
                         .ChangeLocation(request.Lokasi,null)
                         .ChangeInformation(request.Informasi)
                         .Build();

            if (PhysicalAsset.IsFailure)
            {
                return Result.Failure<Guid>(PhysicalAsset.Error);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
