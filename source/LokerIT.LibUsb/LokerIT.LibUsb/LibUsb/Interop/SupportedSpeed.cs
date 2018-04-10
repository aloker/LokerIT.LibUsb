using System;

namespace LokerIT.LibUsb.Interop
{
    [Flags]
    public enum SupportedSpeed
    {
        LowSpeedOperation = 1,
        FullSpeedOperation = 2,
        HighSpeedOperation = 4,
        SuperSpeedOperation = 8
    }
}