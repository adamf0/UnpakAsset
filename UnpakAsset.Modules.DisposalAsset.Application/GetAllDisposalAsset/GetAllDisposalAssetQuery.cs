using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Modules.AssignAsset.Application.GetDisposalAsset;

namespace UnpakAsset.Modules.DisposalAsset.Application.GetDisposalAsset
{
    public sealed record GetAllDisposalAssetQuery() : IQuery<List<DisposalAssetResponse>>;
}
