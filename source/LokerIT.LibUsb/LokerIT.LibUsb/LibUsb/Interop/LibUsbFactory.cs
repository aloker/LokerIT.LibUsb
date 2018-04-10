using System;
using System.Runtime.InteropServices;
using LokerIT.LibUsb.Interop.Linux;
using LokerIT.LibUsb.Interop.Windows;
using Microsoft.Extensions.Logging;

namespace LokerIT.LibUsb.Interop
{
    public class LibUsbFactory : ILibUsbFactory
    {
        private readonly ILoggerFactory _loggerFactory;

        public LibUsbFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public ILibUsb Instantiate()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new LibUsbWindows(_loggerFactory.CreateLogger<LibUsbWindows>());
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new LibUsbLinux(_loggerFactory.CreateLogger<LibUsbLinux>());
            }

            throw new NotSupportedException();
        }
    }
}