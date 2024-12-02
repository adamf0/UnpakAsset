
namespace UnpakAsset.Modules.Tag.Application.GetLocation
{
    public sealed record LocationResponse
    {
        public string Id { get; set; }
        public string Nama { get; set; } = default!;
    }
}
