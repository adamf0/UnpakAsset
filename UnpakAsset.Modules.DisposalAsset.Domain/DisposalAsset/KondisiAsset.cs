using System.Runtime.Serialization;

namespace UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset
{
    public enum TypePhysical
    {
        [EnumMember(Value = "grup")]
        Group,

        [EnumMember(Value = "lokasi")]
        Location

    }
}
