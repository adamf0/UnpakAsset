using System.Runtime.Serialization;

namespace UnpakAsset.Modules.Asset.Domain.Asset
{
    public enum KondisiAsset
    {
        [EnumMember(Value = "baru")]
        Baru,

        [EnumMember(Value = "bekas")]
        Bekas
    }
}
