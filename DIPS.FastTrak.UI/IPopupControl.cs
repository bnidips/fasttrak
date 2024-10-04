namespace DIPS.FastTrak.UI
{
    public interface IPopupControl
    {
        bool GetIsOpen();
        Task OpenAsync();
        Task CloseAsync();
    }
}
