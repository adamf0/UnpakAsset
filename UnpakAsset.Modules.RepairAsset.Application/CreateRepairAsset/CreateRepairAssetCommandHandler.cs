using UnpakAsset.Modules.RepairAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.RepairAsset.Domain.RepairAsset;

namespace UnpakAsset.Modules.RepairAsset.Application.CreateRepairAsset
{
    internal sealed class CreateRepairAssetCommandHandler(
    IRepairAssetRepository RepairAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateRepairAssetCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateRepairAssetCommand request, CancellationToken cancellationToken)
        {
            //check barcode has physical to target [x]

            Result<Domain.RepairAsset.RepairAsset> result = Domain.RepairAsset.RepairAsset.Create(
                request.Tipe,
                request.PIC,
                request.Grup,
                request.SubGrup,
                request.Lokasi,
                request.Informasi
            );

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(result.Error);
            }

            RepairAssetRepository.Insert(result.Value);
            //event change table position asset [x]

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Value.Id;
        }
    }
}
