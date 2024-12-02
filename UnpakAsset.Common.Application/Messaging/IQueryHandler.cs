using MediatR;
using UnpakAsset.Common.Domain;

namespace UnpakAsset.Common.Application.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;

}
