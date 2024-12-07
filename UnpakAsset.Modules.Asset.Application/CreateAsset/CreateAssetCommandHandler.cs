using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Asset.Application.Abstractions.Data;
using UnpakAsset.Modules.Asset.Domain.Asset;

namespace UnpakAsset.Modules.Asset.Application.CreateAsset
{
    internal sealed class CreateAssetCommandHandler(
    IAssetRepository assetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAssetCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Asset.Asset> result = Domain.Asset.Asset.Create(
                request.Nama,
                request.TanggalTerdaftar,
                request.Kondisi,
                request.KodeAset,
                request.Grup,
                request.SubGrup,
                request.Lokasi,
                request.PO,
                request.HargaPerUnit,
                request.TotalUnit
            );

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(result.Error);
            }

            assetRepository.Insert(result.Value);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Value.Id;
        }
    }

}
