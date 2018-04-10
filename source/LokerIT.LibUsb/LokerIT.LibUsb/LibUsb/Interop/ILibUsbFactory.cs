namespace LokerIT.LibUsb.Interop
{
    public interface ILibUsbFactory
    {
        ILibUsb Instantiate();
    }
}