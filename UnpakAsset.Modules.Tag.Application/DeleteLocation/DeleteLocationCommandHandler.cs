using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Domain.Location;

namespace UnpakAsset.Modules.Tag.Application.DeleteLocation
{
    internal sealed class DeleteLocationCommandHandler(
    ILocationRepository groupRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteLocationCommand>
    {
        public async Task<Result> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            Domain.Location.Location? existingLocation = await groupRepository.GetAsync(request.Id, cancellationToken);

            if (existingLocation is null)
            {
                return Result.Failure(LocationErrors.NotFound(request.Id));
            }

            await groupRepository.DeleteAsync(existingLocation!);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
