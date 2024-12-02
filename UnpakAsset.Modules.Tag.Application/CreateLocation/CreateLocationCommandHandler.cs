using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Domain.Location;

namespace UnpakAsset.Modules.Tag.Application.CreateLocation
{
    internal sealed class CreateLocationCommandHandler(
    ILocationRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateLocationCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Location.Location> result = Domain.Location.Location.Create(
                request.Nama
            );

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(result.Error);
            }

            userRepository.Insert(result.Value);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Value.Id;
        }
    }
}
