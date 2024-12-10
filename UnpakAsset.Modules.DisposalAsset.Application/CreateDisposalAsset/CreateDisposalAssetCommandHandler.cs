using UnpakAsset.Modules.DisposalAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Application.CreateDisposalAsset
{
    internal sealed class CreateDisposalAssetCommandHandler(
    IDisposalAssetRepository DisposalAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateDisposalAssetCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateDisposalAssetCommand request, CancellationToken cancellationToken)
        {
            //check barcode has physical to target [x]

            Result<Domain.DisposalAsset.DisposalAsset> result = Domain.DisposalAsset.DisposalAsset.Create(
                request.Tiket,
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

            DisposalAssetRepository.Insert(result.Value);
            //event change table position asset [x]

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Value.Id;
        }
    }
}
