using UnpakAsset.Common.Application.Clock;

namespace UnpakAsset.Common.Infrastructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
