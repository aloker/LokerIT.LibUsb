using System;
using System.Linq;
using System.Text;
using LokerIT.LibUsb.Interop;
using LokerIT.LibUsb.Interop.Windows;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;

namespace LokerIT.LibUsb.TestDrive
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            var factory = CreateLoggerFactory();

            var app = factory.CreateLogger<Program>();

            app.LogInformation("Start");

            using (var impl = new LibUsbFactory(factory).Instantiate())
            {
                var context = IntPtr.Zero;
                var list = IntPtr.Zero;
                try
                {
                    if (impl.libusb_init(out context) != Result.Success)
                    {
                        return;
                    }

                    //impl.libusb_set_option(context, Option.LogLevel, LogLevel.Debug);

                    var res = impl.libusb_get_device_list(context, out list);
                    if (res < 0)
                    {
                        return;
                    }

                    var listLength = (int) res;
                    var devices = (void**) list;
                    for (var i = 0; i < listLength; ++i)
                    {
                        app.LogDebug("-------------------------------------");
                        var device = new IntPtr(devices[i]);

                        impl.libusb_get_device_descriptor(device, out var desc);
                        var vendorId = $"0x{desc.idVendor:x4}";
                        var productId = $"0x{desc.idProduct:x4}";

                        app.LogDebug("VendorID: {VendorId} ProductID: {ProductID}", vendorId, productId);

                        
                        var result = impl.libusb_open(device, out var deviceHandle);
                        if (result == Result.Success)
                        {
                            try
                            {
                                app.LogDebug(
                                    "Manufacturer: {Manufacturer}",
                                    GetStringDescriptor(impl, deviceHandle, desc.iManufacturer,
                                        desc.idVendor.ToString("X4")));
                                app.LogDebug(
                                    "Product: {Product}",
                                    GetStringDescriptor(impl, deviceHandle, desc.iProduct,
                                        desc.idProduct.ToString("X4")));
                                app.LogDebug(
                                    "Serial: {Serial}",
                                    GetStringDescriptor(impl, deviceHandle, desc.iSerialNumber, "?"));
                            }
                            finally
                            {
                                impl.libusb_close(deviceHandle);
                            }
                        }
                        else
                        {
                            app.LogWarning("Could not open device {VendorId}:{ProductId}: {Result}", vendorId,
                                productId, result);
                        }


                        var busNumber = impl.libusb_get_bus_number(device);
                        var deviceAddress = impl.libusb_get_device_address(device);
                        var speed = impl.libusb_get_device_speed(device);

                        app.LogDebug("Bus number     = {BusNumber}", busNumber);
                        app.LogDebug("Device address = {DeviceAddress}", deviceAddress);
                        app.LogDebug("Device Speed   = {Speed}", speed);
                        var pn = new byte[15];
                        res = impl.libusb_get_port_numbers(device, pn);
                        if (res > 0)
                        {
                            app.LogDebug("Path           = {Path}", string.Join(".", pn.Take((int) res)));
                        }

                        app.LogDebug("Descriptor: {Descriptor}",
                            JsonConvert.SerializeObject(desc, Formatting.Indented));
                    }
                }
                finally
                {
                    if (list != IntPtr.Zero)
                    {
                        impl.libusb_free_device_list(list, 1);
                    }

                    if (context != IntPtr.Zero)
                    {
                        impl.libusb_exit(context);
                    }
                }
            }
        }

        private static ILoggerFactory CreateLoggerFactory()
        {
            return new LoggerFactory()
                .AddSerilog(new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger());
        }

        private static unsafe string GetStringDescriptor(ILibUsb impl, IntPtr deviceHandle, byte index,
            string fallback)
        {
            const int Buffer = 255;
            byte[] str = new byte[Buffer];
            if (index > 0)
            {
                fixed (byte* ptr = str)
                {
                    var res = impl.libusb_get_string_descriptor(deviceHandle, 0, 0, new IntPtr(ptr), Buffer);
                    if ((int) res < 4)
                    {
                        return fallback;
                    }

                    var langId = (ushort) (str[2] | (str[3] << 8));
                    res = impl.libusb_get_string_descriptor(deviceHandle, index, langId, new IntPtr(ptr), Buffer);
                    if (res < 0)
                    {
                        return fallback;
                    }

                    if (str[1] != (int) DescriptorType.LIBUSB_DT_STRING)
                    {
                        return fallback;
                    }

                    if (str[0] > (int) res)
                    {
                        return fallback;
                    }

                    return Encoding.Unicode.GetString(str, 2, (int) res);
                }
            }

            return fallback;
        }
    }
}