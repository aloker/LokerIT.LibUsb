namespace LokerIT.LibUsb.Interop
{
    public enum DeviceClass : byte
    {
        /** In the context of a \ref libusb_device_descriptor "device descriptor",
	 * this bDeviceClass value indicates that each interface specifies its
	 * own class information and all interfaces operate independently.
	 */
        PerInterface = 0,

        /** Audio class */
        Audio = 1,

        /** Communications class */
        Communications = 2,

        /** Human Interface Device class */
        Hid = 3,

        /** Physical */
        Physical = 5,
        
        /** Image class */
        Image = 6,

        /** Printer class */
        Printer = 7,

        /** Mass storage class */
        MassStorage = 8,

        /** Hub class */
        Hub = 9,

        /** Data class */
        CdcData = 0x0a,

        /** Smart Card */
        SmartCard = 0x0b,

        /** Content Security */
        Security = 0x0d,

        /** Video */
        Video = 0x0e,

        /** Personal Healthcare */
        PersonalHealthcare = 0x0f,
        
        AudioVideo =0x10,
        Billboard = 0x11,
        UsbCBridge = 0x12,

        /** Diagnostic Device */
        Diagnostics = 0xdc,

        /** Wireless class */
        Wireless = 0xe0,
        
        Miscellaneous = 0xef,

        /** Application class */
        ApplicationSpecific = 0xfe,

        /** Class is vendor-specific */
        VendorSpecific = 0xff
    }
}