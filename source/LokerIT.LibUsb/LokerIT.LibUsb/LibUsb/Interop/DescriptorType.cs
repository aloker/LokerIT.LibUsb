namespace LokerIT.LibUsb.Interop
{
    public enum DescriptorType : byte
    {
        /** Device descriptor. See libusb_device_descriptor. */
        LIBUSB_DT_DEVICE = 0x01,

        /** Configuration descriptor. See libusb_config_descriptor. */
        LIBUSB_DT_CONFIG = 0x02,

        /** String descriptor */
        LIBUSB_DT_STRING = 0x03,

        /** Interface descriptor. See libusb_interface_descriptor. */
        LIBUSB_DT_INTERFACE = 0x04,

        /** Endpoint descriptor. See libusb_endpoint_descriptor. */
        LIBUSB_DT_ENDPOINT = 0x05,

        /** BOS descriptor */
        LIBUSB_DT_BOS = 0x0f,

        /** Device Capability descriptor */
        LIBUSB_DT_DEVICE_CAPABILITY = 0x10,

        /** HID descriptor */
        LIBUSB_DT_HID = 0x21,

        /** HID report descriptor */
        LIBUSB_DT_REPORT = 0x22,

        /** Physical descriptor */
        LIBUSB_DT_PHYSICAL = 0x23,

        /** Hub descriptor */
        LIBUSB_DT_HUB = 0x29,

        /** SuperSpeed Hub descriptor */
        LIBUSB_DT_SUPERSPEED_HUB = 0x2a,

        /** SuperSpeed Endpoint Companion descriptor */
        LIBUSB_DT_SS_ENDPOINT_COMPANION = 0x30
    }
}