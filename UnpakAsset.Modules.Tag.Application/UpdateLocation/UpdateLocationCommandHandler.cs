using UnpakAsset.Modules.Tag.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Domain.Location;

namespace UnpakAsset.Modules.Tag.Application.UpdateLocation
{
    internal sealed class UpdateLocationCommandHandler(
    ILocationRepository groupRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateLocationCommand>
    {
        public async Task<Result> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            Domain.Location.Location? existingLocation = await groupRepository.GetAsync(request.Id, cancellationToken);

            if (existingLocation is null)
            {
                Result.Failure(LocationErrors.NotFound(request.Id));
            }

            Result<Domain.Location.Location> asset = Domain.Location.Location.Update(existingLocation!)
                         .ChangeNama(request.Nama)
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
