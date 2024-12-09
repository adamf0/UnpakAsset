using UnpakAsset.Modules.MoveAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.MoveAsset.Domain.MoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Application.UpdateMoveAsset
{
    internal sealed class UpdateMoveAssetCommandHandler(
    IMoveAssetRepository moveAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateMoveAssetCommand>
    {
        public async Task<Result> Handle(UpdateMoveAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.MoveAsset.MoveAsset? existingMoveAsset = await moveAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingMoveAsset is null)
            {
                Result.Failure(MoveAssetErrors.NotFound(request.Id));
            }

            //paralel async await
            //check barcode
            //check asset disposal is not null -> throw = api [x]
            
            Result<Domain.MoveAsset.MoveAsset> MoveAsset = Domain.MoveAsset.MoveAsset.Update(existingMoveAsset!)
                         .ChangeTicket(request.Tiket)
                         .ChangeType(request.Tipe)
                         .ChangePIC(request.PIC)
                         .ChangeGroup(request.Grup,null)
                         .ChangeSubGroup(request.SubGrup,null)
                         .ChangeLocation(request.Lokasi,null)
                         .ChangeGroup(request.GrupTarget, "target")
                         .ChangeSubGroup(request.SubGrupTarget, "target")
                         .ChangeLocation(request.LokasiTarget, "target")
                         .ChangeUserTarget(request.UserTarget)
                         .ChangeInformation(request.Informasi)
                         .Build();

            if (MoveAsset.IsFailure)
            {
                return Result.Failure<Guid>(MoveAsset.Error);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
