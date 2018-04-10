namespace LokerIT.LibUsb.Interop
{
    public enum StandardRequest : byte
    {
        /** Request status of the specific recipient */
        LIBUSB_REQUEST_GET_STATUS = 0x00,

        /** Clear or disable a specific feature */
        LIBUSB_REQUEST_CLEAR_FEATURE = 0x01,

        /* 0x02 is reserved */

        /** Set or enable a specific feature */
        LIBUSB_REQUEST_SET_FEATURE = 0x03,

        /* 0x04 is reserved */

        /** Set device address for all future accesses */
        LIBUSB_REQUEST_SET_ADDRESS = 0x05,

        /** Get the specified descriptor */
        LIBUSB_REQUEST_GET_DESCRIPTOR = 0x06,

        /** Used to update existing descriptors or add new descriptors */
        LIBUSB_REQUEST_SET_DESCRIPTOR = 0x07,

        /** Get the current device configuration value */
        LIBUSB_REQUEST_GET_CONFIGURATION = 0x08,

        /** Set device configuration */
        LIBUSB_REQUEST_SET_CONFIGURATION = 0x09,

        /** Return the selected alternate setting for the specified interface */
        LIBUSB_REQUEST_GET_INTERFACE = 0x0A,

        /** Select an alternate interface for the specified interface */
        LIBUSB_REQUEST_SET_INTERFACE = 0x0B,

        /** Set then report an endpoint's synchronization frame */
        LIBUSB_REQUEST_SYNCH_FRAME = 0x0C,

        /** Sets both the U1 and U2 Exit Latency */
        LIBUSB_REQUEST_SET_SEL = 0x30,

        /** Delay from the time a host transmits a packet to the time it is
          * received by the device. */
        LIBUSB_SET_ISOCH_DELAY = 0x31
    }
}