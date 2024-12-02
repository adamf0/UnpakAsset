using MediatR;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Common.Application.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand;

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

    public interface IBaseCommand;
}
