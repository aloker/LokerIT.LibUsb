using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LokerIT.LibUsb.Interop.LinuxArm
{
    public static class Native
    {
        private const string Dll = "libusb-1.0.so.0";

        [DllImport(Dll)]
        public static extern IntPtr libusb_get_version();

        [DllImport(Dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern Result libusb_set_option(IntPtr context, Option option, int value);

        [DllImport(Dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern Result libusb_set_option(IntPtr context, Option option);

        [DllImport(Dll)]
        public static extern Result libusb_init(out IntPtr context);

        [DllImport(Dll)]
        public static extern void libusb_exit(IntPtr context);

        [DllImport(Dll)]
        public static extern Result libusb_get_device_list(IntPtr context, out IntPtr ptrList);

        [DllImport(Dll)]
        public static extern void libusb_free_device_list(IntPtr list, int unrefDevices);

        [DllImport(Dll)]
        public static extern byte libusb_get_bus_number(IntPtr device);

        [DllImport(Dll)]
        public static extern byte libusb_get_port_number(IntPtr device);

        [DllImport(Dll)]
        public static extern Result libusb_get_port_numbers(IntPtr device, [Out] byte[] portNumbers,
            int portNumbersLength);

        [DllImport(Dll)]
        public static extern IntPtr libusb_get_parent(IntPtr device);

        [DllImport(Dll)]
        public static extern byte libusb_get_device_address(IntPtr device);

        [DllImport(Dll)]
        public static extern Speed libusb_get_device_speed(IntPtr device);

        [DllImport(Dll)]
        public static extern Result libusb_get_max_packet_size(IntPtr device, byte endpoint);

        [DllImport(Dll)]
        public static extern Result libusb_get_max_iso_packet_size(IntPtr device, byte endpoint);

        [DllImport(Dll)]
        public static extern IntPtr libusb_ref_device(IntPtr device);

        [DllImport(Dll)]
        public static extern void libusb_unref_device(IntPtr device);

        [DllImport(Dll)]
        public static extern Result libusb_open(IntPtr device, out IntPtr deviceHandle);

        [DllImport(Dll)]
        public static extern IntPtr libusb_open_device_with_vid_pid(IntPtr context, ushort vendorId, ushort productId);

        [DllImport(Dll)]
        public static extern void libusb_close(IntPtr deviceHandle);
        
        [DllImport(Dll)]
        public static extern IntPtr libusb_get_device(IntPtr deviceHandle);

        [DllImport(Dll)]
        public static extern Result libusb_get_configuration(IntPtr deviceHandle, ref int config);
        
        [DllImport(Dll)]
        public static extern Result libusb_set_configuration(IntPtr deviceHandle, int config);
        
        [DllImport(Dll)]
        public static extern Result libusb_claim_interface(IntPtr deviceHandle, int interfaceNumber);
        
        [DllImport(Dll)]
        public static extern Result libusb_release_interface(IntPtr deviceHandle, int interfaceNumber);
        
        [DllImport(Dll)]
        public static extern Result libusb_set_interface_alt_setting(IntPtr deviceHandle, int interfaceNumber, int alternateSetting);
        
        [DllImport(Dll)]
        public static extern Result libusb_clear_halt(IntPtr deviceHandle, byte endpoint);
        
        [DllImport(Dll)]
        public static extern Result libusb_reset_device(IntPtr deviceHandle);
        
        [DllImport(Dll)]
        public static extern Result libusb_get_device_descriptor(IntPtr device, out DeviceDescriptor descriptor);
        
        [DllImport(Dll)]
        public static extern Result libusb_control_transfer(IntPtr deviceHandle, byte requestType, byte request,
            ushort value, ushort index, IntPtr data, ushort length, int timeout);
    }
}