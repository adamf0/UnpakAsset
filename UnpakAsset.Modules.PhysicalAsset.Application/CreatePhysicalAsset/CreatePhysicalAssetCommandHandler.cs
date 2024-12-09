using UnpakAsset.Modules.PhysicalAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset;

namespace UnpakAsset.Modules.PhysicalAsset.Application.CreatePhysicalAsset
{
    internal sealed class CreatePhysicalAssetCommandHandler(
    IPhysicalAssetRepository physicalAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePhysicalAssetCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreatePhysicalAssetCommand request, CancellationToken cancellationToken)
        {
            //check barcode has physical to target [x]

            Result<Domain.PhysicalAsset.PhysicalAsset> result = Domain.PhysicalAsset.PhysicalAsset.Create(
                request.Tipe,
                request.TanggalMulai,
                request.TanggalAkhir,
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

            physicalAssetRepository.Insert(result.Value);
            //event change table position asset [x]

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Value.Id;
        }
    }
}
