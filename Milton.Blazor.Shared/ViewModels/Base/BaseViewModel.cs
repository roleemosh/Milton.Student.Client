using Milton.Blazor.Shared.Interfaces;
using MudBlazor;

namespace Milton.Blazor.Shared.ViewModels.Base
{
    public abstract class BaseViewModel : NotifiedObject
    {
        public bool IsBusy
        #region
        {
            get => _isBusy;
            set => SetPropertyValue(ref _isBusy, value);
        }
        private static bool _isBusy;

        protected BaseViewModel(IPageTitleService pageTitleService, ISnackbar snackbar)
        {
            PageTitleService = pageTitleService;
            Snackbar = snackbar;
        }
        #endregion

        public IPageTitleService PageTitleService { get; private set; }
        public ISnackbar Snackbar { get; private set; }

        protected abstract void UpdateMainTitle();

        protected void ShowSnakbar(string message, Severity type)
        {
           this.Snackbar.Add(message, type);
        }
    }
}
