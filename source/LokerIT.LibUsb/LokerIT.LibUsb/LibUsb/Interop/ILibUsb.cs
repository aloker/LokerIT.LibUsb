using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LokerIT.LibUsb.Interop
{
    public interface ILibUsb : IDisposable
    {
        IntPtr libusb_get_version();
        Result libusb_set_option(IntPtr context, Option option, LogLevel value);
        Result libusb_set_option(IntPtr context, Option option);
        Result libusb_init(out IntPtr context);
        void libusb_exit(IntPtr context);
        Result libusb_get_device_list(IntPtr context, out IntPtr ptrList);
        void libusb_free_device_list(IntPtr list, int unrefDevices);
        byte libusb_get_bus_number(IntPtr device);
        byte libusb_get_port_number(IntPtr device);
        Result libusb_get_port_numbers(IntPtr device, byte[] portNumbers);
        IntPtr libusb_get_parent(IntPtr device);
        byte libusb_get_device_address(IntPtr device);
        Speed libusb_get_device_speed(IntPtr device);
        Result libusb_get_max_packet_size(IntPtr device, byte endpoint);
        Result libusb_get_max_iso_packet_size(IntPtr device, byte endpoint);
        IntPtr libusb_ref_device(IntPtr device);
        void libusb_unref_device(IntPtr device);
        Result libusb_open(IntPtr device, out IntPtr deviceHandle);
        IntPtr libusb_open_device_with_vid_pid(IntPtr context, ushort vendorId, ushort productId);
        void libusb_close(IntPtr deviceHandle);
        IntPtr libusb_get_device(IntPtr deviceHandle);
        Result libusb_get_configuration(IntPtr deviceHandle, ref int config);
        Result libusb_set_configuration(IntPtr deviceHandle, int config);
        Result libusb_claim_interface(IntPtr deviceHandle, int interfaceNumber);
        Result libusb_release_interface(IntPtr deviceHandle, int interfaceNumber);
        Result libusb_set_interface_alt_setting(IntPtr deviceHandle, int interfaceNumber, int alternateSetting);
        Result libusb_clear_halt(IntPtr deviceHandle, byte endpoint);
        Result libusb_reset_device(IntPtr deviceHandle);
        Result libusb_get_device_descriptor(IntPtr device, out DeviceDescriptor descriptor);

        Result libusb_control_transfer(IntPtr deviceHandle, byte requestType, byte request,
            ushort value, ushort index, IntPtr data, ushort length, int timeout);
    }
}