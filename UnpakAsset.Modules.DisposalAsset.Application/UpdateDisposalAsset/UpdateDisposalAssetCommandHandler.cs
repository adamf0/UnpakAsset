using UnpakAsset.Modules.DisposalAsset.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Application.UpdateDisposalAsset
{
    internal sealed class UpdateDisposalAssetCommandHandler(
    IDisposalAssetRepository assignAssetRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateDisposalAssetCommand>
    {
        public async Task<Result> Handle(UpdateDisposalAssetCommand request, CancellationToken cancellationToken)
        {
            Domain.DisposalAsset.DisposalAsset? existingDisposalAsset = await assignAssetRepository.GetAsync(request.Id, cancellationToken);

            if (existingDisposalAsset is null)
            {
                Result.Failure(DisposalAssetErrors.NotFound(request.Id));
            }

            //paralel async await
            //check barcode
            //check asset disposal is not null -> throw = api [x]
            
            Result<Domain.DisposalAsset.DisposalAsset> DisposalAsset = Domain.DisposalAsset.DisposalAsset.Update(existingDisposalAsset!)
                         .ChangeTicket(request.Tiket)
                         .ChangeType(request.Tipe)
                         .ChangePIC(request.PIC)
                         .ChangeGroup(request.Grup,null)
                         .ChangeSubGroup(request.SubGrup,null)
                         .ChangeLocation(request.Lokasi,null)
                         .ChangeInformation(request.Informasi)
                         .Build();

            if (DisposalAsset.IsFailure)
            {
                return Result.Failure<Guid>(DisposalAsset.Error);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
