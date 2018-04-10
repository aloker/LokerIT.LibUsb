using System.Runtime.InteropServices;
using LokerIT.LibUsb.Interop.Win64;
using LokerIT.LibUsb.Interop.Windows;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace LokerIT.LibUsb.Interop
{
    public class LibUsbTests
    {
        
        [Fact]
        public void GetVersion_WhenCalled_ReturnsCorrectVersion()
        {
            var instance = Instantiate();
            var c = instance.libusb_get_version();
            var str = Marshal.PtrToStructure<Version>(c);
            Assert.Equal(1, str.major);
            Assert.Equal(0, str.minor);
            Assert.Equal(22, str.micro);
            Assert.Equal(11312, str.nano);
        }

        private static ILibUsb Instantiate()
        {
            return new LibUsbWindows(Substitute.For<ILogger<LibUsbWindows>>());
        }
    }
}