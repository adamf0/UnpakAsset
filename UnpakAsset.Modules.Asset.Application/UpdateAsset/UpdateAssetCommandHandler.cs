using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Modules.Asset.Domain.Asset;

namespace UnpakAsset.Modules.Asset.Application.UpdateAsset
{
    internal sealed class UpdateAssetCommandHandler(
    IAssetRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateAssetCommand>
    {
        public async Task<Result> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.Asset.Asset? existingAsset = await userRepository.GetAsync(request.Id, cancellationToken);

            if (existingAsset is null)
            {
                Result.Failure(AssetErrors.NotFound(request.Id));
            }

            Result<Domain.Asset.Asset> asset = Domain.Asset.Asset.Update(existingAsset!)
                         .ChangeNama(request.Nama)
                         .ChangeTanggalTerdaftar(request.TanggalTerdaftar)
                         .ChangeKondisi(request.Kondisi)
                         .ChangeKodeAsset(request.KodeAset)
                         .ChangeGrup(request.Grup)
                         .ChangeSubGrup(request.SubGrup)
                         .ChangeLokasi(request.Lokasi)
                         .ChangePO(request.PO)
                         .ChangeHargaPerUnit(decimal.Parse(request.HargaPerUnit))
                         .ChangeTotalUnit(int.Parse(request.TotalUnit))
                         .Build();

            if (asset.IsFailure)
            {
                return Result.Failure<Guid>(asset.Error);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }

}
