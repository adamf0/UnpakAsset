using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Application.Abstractions.Data;
using UnpakAsset.Modules.Tag.Domain.Group;

namespace UnpakAsset.Modules.Tag.Application.UpdateGroup
{
    internal sealed class UpdateGroupCommandHandler(
    IGroupRepository groupRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateGroupCommand>
    {
        public async Task<Result> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            Domain.Group.Group? existingGroup = await groupRepository.GetAsync(request.Id, cancellationToken);

            if (existingGroup is null)
            {
                Result.Failure(GroupErrors.NotFound(request.Id));
            }

            Result<Domain.Group.Group> asset = Domain.Group.Group.Update(existingGroup!)
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
