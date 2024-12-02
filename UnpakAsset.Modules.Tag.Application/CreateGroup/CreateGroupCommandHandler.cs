using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Modules.Tag.Domain.Group;

namespace UnpakAsset.Modules.Tag.Application.CreateGroup
{
    internal sealed class CreateGroupCommandHandler(
    IGroupRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateGroupCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Group.Group> result = Domain.Group.Group.Create(
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
