using MediatR;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Common.Application.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
}
