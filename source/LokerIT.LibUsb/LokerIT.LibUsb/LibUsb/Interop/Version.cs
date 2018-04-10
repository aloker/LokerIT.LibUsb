using System;
using System.Runtime.InteropServices;

namespace LokerIT.LibUsb.Interop
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public readonly struct Version {
        public override string ToString()
        {
            var versionNumber = new System.Version(major, minor, micro, nano);
            var suffix = string.IsNullOrEmpty(rc) ? string.Empty : $"-{rc}";

            return versionNumber + suffix;
        }

        /** Library major version. */
        public readonly ushort major;

        /** Library minor version. */
        public readonly ushort minor;

        /** Library micro version. */
        public readonly ushort micro;

        /** Library nano version. */
        public readonly ushort nano;

        /** Library release candidate suffix string, e.g. "-rc4". */
        public readonly string rc;

        /** For ABI compatibility only. */
        public readonly string describe;
    };
}