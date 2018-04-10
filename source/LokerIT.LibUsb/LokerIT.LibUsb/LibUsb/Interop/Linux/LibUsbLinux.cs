using System;
using System.Linq;
using System.Runtime.InteropServices;
using LokerIT.LibUsb.Interop.LinuxArm;
using Microsoft.Extensions.Logging;

namespace LokerIT.LibUsb.Interop.Linux
{
    public class LibUsbLinux : ILibUsb
    {
        public LibUsbLinux(ILogger<LibUsbLinux> logger)
        {
            var osPlatform = new[] {OSPlatform.Linux, OSPlatform.OSX, OSPlatform.Windows}
                .First(RuntimeInformation.IsOSPlatform);
            var arc = RuntimeInformation.ProcessArchitecture;

            if (osPlatform != OSPlatform.Linux)
            {
                logger.LogCritical(
                    "Platform {OsPlatform}-{ProcessArchitecture} is not supported by this implementation of ILibUsb",
                    osPlatform, arc);
                throw new NotSupportedException($"{OSPlatform.Windows} {arc} is not supported");
            }

            logger.LogInformation("Using libusb on {OsPlatform}-{ProcessArchitecture}",
                osPlatform, arc);

            var ver = Native.libusb_get_version();
            var version = Marshal.PtrToStructure<Version>(ver);
            logger.LogInformation("libusb {Version} loaded", version);
        }

        public IntPtr libusb_get_version()
        {
            return Native.libusb_get_version();
        }

        public Result libusb_set_option(IntPtr context, Option option, LogLevel value)
        {
            return Native.libusb_set_option(context, option, (int) value);
        }

        public Result libusb_set_option(IntPtr context, Option option)
        {
            return Native.libusb_set_option(context, option);
        }

        public Result libusb_init(out IntPtr context)
        {
            return Native.libusb_init(out context);
        }

        public void libusb_exit(IntPtr context)
        {
            Native.libusb_exit(context);
        }

        public Result libusb_get_device_list(IntPtr context, out IntPtr ptrList)
        {
            return Native.libusb_get_device_list(context, out ptrList);
        }

        public void libusb_free_device_list(IntPtr list, int unrefDevices)
        {
            Native.libusb_free_device_list(list, unrefDevices);
        }

        public byte libusb_get_bus_number(IntPtr device)
        {
            return Native.libusb_get_bus_number(device);
        }

        public byte libusb_get_port_number(IntPtr device)
        {
            return Native.libusb_get_port_number(device);
        }

        public Result libusb_get_port_numbers(IntPtr device, byte[] portNumbers)
        {
            return Native.libusb_get_port_numbers(device, portNumbers, portNumbers.Length);
        }

        public IntPtr libusb_get_parent(IntPtr device)
        {
            return Native.libusb_get_parent(device);
        }

        public byte libusb_get_device_address(IntPtr device)
        {
            return Native.libusb_get_device_address(device);
        }

        public Speed libusb_get_device_speed(IntPtr device)
        {
            return Native.libusb_get_device_speed(device);
        }

        public Result libusb_get_max_packet_size(IntPtr device, byte endpoint)
        {
            return Native.libusb_get_max_packet_size(device, endpoint);
        }

        public Result libusb_get_max_iso_packet_size(IntPtr device, byte endpoint)
        {
            return Native.libusb_get_max_iso_packet_size(device, endpoint);
        }

        public IntPtr libusb_ref_device(IntPtr device)
        {
            return Native.libusb_ref_device(device);
        }

        public void libusb_unref_device(IntPtr device)
        {
            Native.libusb_unref_device(device);
        }

        public Result libusb_open(IntPtr device, out IntPtr deviceHandle)
        {
            return Native.libusb_open(device, out deviceHandle);
        }

        public IntPtr libusb_open_device_with_vid_pid(IntPtr context, ushort vendorId, ushort productId)
        {
            return Native.libusb_open_device_with_vid_pid(context, vendorId, productId);
        }

        public void libusb_close(IntPtr deviceHandle)
        {
            Native.libusb_close(deviceHandle);
        }

        public IntPtr libusb_get_device(IntPtr deviceHandle)
        {
            return Native.libusb_get_device(deviceHandle);
        }

        public Result libusb_get_configuration(IntPtr deviceHandle, ref int config)
        {
            return Native.libusb_get_configuration(deviceHandle, ref config);
        }

        public Result libusb_set_configuration(IntPtr deviceHandle, int config)
        {
            return Native.libusb_set_configuration(deviceHandle, config);
        }

        public Result libusb_claim_interface(IntPtr deviceHandle, int interfaceNumber)
        {
            return Native.libusb_claim_interface(deviceHandle, interfaceNumber);
        }

        public Result libusb_release_interface(IntPtr deviceHandle, int interfaceNumber)
        {
            return Native.libusb_release_interface(deviceHandle, interfaceNumber);
        }

        public Result libusb_set_interface_alt_setting(IntPtr deviceHandle, int interfaceNumber, int alternateSetting)
        {
            return Native.libusb_set_interface_alt_setting(deviceHandle, interfaceNumber, alternateSetting);
        }

        public Result libusb_clear_halt(IntPtr deviceHandle, byte endpoint)
        {
            return Native.libusb_clear_halt(deviceHandle, endpoint);
        }

        public Result libusb_reset_device(IntPtr deviceHandle)
        {
            return Native.libusb_reset_device(deviceHandle);
        }

        public Result libusb_get_device_descriptor(IntPtr device, out DeviceDescriptor descriptor)
        {
            return Native.libusb_get_device_descriptor(device, out descriptor);
        }

        public Result libusb_control_transfer(IntPtr deviceHandle, byte requestType, byte request, ushort value,
            ushort index,
            IntPtr data, ushort length, int timeout)
        {
            return Native.libusb_control_transfer(deviceHandle, requestType, request, value, index, data, length,
                timeout);
        }

        public void Dispose()
        {
        }
    }
}