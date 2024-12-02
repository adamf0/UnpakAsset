using System.Reflection;

namespace UnpakAsset.Modules.Asset.Application
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
