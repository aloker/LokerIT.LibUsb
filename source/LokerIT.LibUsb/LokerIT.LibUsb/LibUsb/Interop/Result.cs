namespace LokerIT.LibUsb.Interop
{
    public enum Result
    {
        /** Success (no error) */
        Success = 0,

        /** Input/output error */
        IO = -1,

        /** Invalid parameter */
        InvalidParam = -2,

        /** Access denied (insufficient permissions) */
        AccessDenied = -3,

        /** No such device (it may have been disconnected) */
        NoDevice = -4,

        /** Entity not found */
        NotFound = -5,

        /** Resource busy */
        Busy = -6,

        /** Operation timed out */
        Timeout = -7,

        /** Overflow */
        Overflow = -8,

        /** Pipe error */
        Pipe = -9,

        /** System call interrupted (perhaps due to signal) */
        Interrupted = -10,

        /** Insufficient memory */
        NoMem = -11,

        /** Operation not supported or unimplemented on this platform */
        NotSupported = -12,

        /** Other error */
        Other = -99
    };
}