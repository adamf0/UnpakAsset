using System.Runtime.Serialization;

namespace UnpakAsset.Modules.RepairAsset.Domain.RepairAsset
{
    public enum TypePhysical
    {
        [EnumMember(Value = "grup")]
        Group,

        [EnumMember(Value = "lokasi")]
        Location

    }
}
