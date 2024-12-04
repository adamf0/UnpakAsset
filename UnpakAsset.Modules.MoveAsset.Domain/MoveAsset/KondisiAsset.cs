using System.Runtime.Serialization;

namespace UnpakAsset.Modules.MoveAsset.Domain.MoveAsset
{
    public enum TypeMove
    {
        [EnumMember(Value = "grup")]
        Group,

        [EnumMember(Value = "lokasi")]
        Location,

        [EnumMember(Value = "personal")]
        Personal
    }
}
