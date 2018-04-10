using System;

namespace LokerIT.LibUsb.Interop
{
    public static class LibUsbExtensions
    {
        public static Result libusb_get_string_descriptor(this ILibUsb lib, IntPtr deviceHandle,
            byte index, ushort langId, IntPtr data, int length)
        {
            return lib.libusb_control_transfer(deviceHandle, 
                (byte) EndpointDirection.In,
                (byte) StandardRequest.LIBUSB_REQUEST_GET_DESCRIPTOR, 
                (ushort)(((byte)DescriptorType.LIBUSB_DT_STRING << 8) | index),
                langId, 
                data, 
                (ushort) length, 
                1000);
        }
    }
}