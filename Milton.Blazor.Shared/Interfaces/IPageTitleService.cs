namespace Milton.Blazor.Shared.Interfaces
{
    public interface IPageTitleService
    {
        string MainTitle { get; set; }
        string SubTitle { get; set; }

        event Action OnTitleChanged;
        void InvokeOnTitleChanged();
    }
}
