namespace UnpakAsset.Common.Domain
{
    public interface IDomainEvent
    {
        Guid Id { get; }

        DateTime OccurredOnUtc { get; }
    }

}
