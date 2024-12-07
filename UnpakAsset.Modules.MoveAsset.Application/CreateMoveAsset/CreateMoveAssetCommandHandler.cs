using UnpakAsset.Modules.MoveAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.MoveAsset.Domain.MoveAsset;

namespace UnpakAsset.Modules.MoveAsset.Application.CreateMoveAsset
{
    internal sealed class CreateMoveAssetCommandHandler(
    IMoveAssetRepository moveAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateMoveAssetCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateMoveAssetCommand request, CancellationToken cancellationToken)
        {
            //check barcode has move to target [x]

            Result<Domain.MoveAsset.MoveAsset> result = Domain.MoveAsset.MoveAsset.Create(
                request.Tiket,
                request.Tipe,
                request.PIC,
                request.Grup,
                request.SubGrup,
                request.Lokasi,
                request.GrupTarget,
                request.SubGrupTarget,
                request.LokasiTarget,
                request.UserTarget,
                request.Informasi
            );

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(result.Error);
            }

            moveAssetRepository.Insert(result.Value);
            //event change table position asset [x]

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Value.Id;
        }
    }
}
