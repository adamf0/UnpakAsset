using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Common.Domain;
using UnpakAsset.Common.Application.Abstractions.Data;
using UnpakAsset.Modules.Tag.Domain.Group;

namespace UnpakAsset.Modules.Tag.Application.DeleteGroup
{
    internal sealed class DeleteGroupCommandHandler(
    IGroupRepository groupRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteGroupCommand>
    {
        public async Task<Result> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            Domain.Group.Group? existingGroup = await groupRepository.GetAsync(request.Id, cancellationToken);

            if (existingGroup is null)
            {
                return Result.Failure(GroupErrors.NotFound(request.Id));
            }

            await groupRepository.DeleteAsync(existingGroup!);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
