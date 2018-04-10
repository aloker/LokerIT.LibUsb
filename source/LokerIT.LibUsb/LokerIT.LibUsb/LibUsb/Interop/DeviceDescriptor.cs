using System.Runtime.InteropServices;

namespace LokerIT.LibUsb.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DeviceDescriptor
    {
        /** Size of this descriptor (in bytes) */
        public readonly byte bLength;

        /** Descriptor type. Will have value
         * \ref libusb_descriptor_type::LIBUSB_DT_DEVICE LIBUSB_DT_DEVICE in this
         * context. */
        public readonly byte bDescriptorType;

        /** USB specification release number in binary-coded decimal. A value of
         * 0x0200 indicates USB 2.0, 0x0110 indicates USB 1.1, etc. */
        public readonly ushort bcdUSB;

        /** USB-IF class code for the device. See \ref libusb_class_code. */
        public readonly DeviceClass bDeviceClass;

        /** USB-IF subclass code for the device, qualified by the bDeviceClass
         * value */
        public readonly byte bDeviceSubClass;

        /** USB-IF protocol code for the device, qualified by the bDeviceClass and
         * bDeviceSubClass values */
        public readonly byte bDeviceProtocol;

        /** Maximum packet size for endpoint 0 */
        public readonly byte bMaxPacketSize0;

        /** USB-IF vendor ID */
        public readonly ushort idVendor;

        /** USB-IF product ID */
        public readonly ushort idProduct;

        /** Device release number in binary-coded decimal */
        public readonly ushort bcdDevice;

        /** Index of string descriptor describing manufacturer */
        public readonly byte iManufacturer;

        /** Index of string descriptor describing product */
        public readonly byte iProduct;

        /** Index of string descriptor containing device serial number */
        public readonly byte iSerialNumber;

        /** Number of possible configurations */
        public readonly byte bNumConfigurations;
    }
}