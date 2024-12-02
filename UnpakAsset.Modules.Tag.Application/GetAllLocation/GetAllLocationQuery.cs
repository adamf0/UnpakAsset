using UnpakAsset.Common.Application.Messaging;
using UnpakAsset.Modules.Tag.Application.GetLocation;

namespace UnpakAsset.Modules.Tag.Application.GetAllLocation
{
    public sealed record GetAllLocationQuery() : IQuery<List<LocationResponse>>;
}
