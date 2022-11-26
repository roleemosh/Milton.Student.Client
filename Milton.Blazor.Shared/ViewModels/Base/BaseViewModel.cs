using Microsoft.AspNetCore.Components;
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
        #endregion

        public IPageTitleService PageTitleService { get; private set; }
        public ISnackbar Snackbar { get; private set; }
        public NavigationManager Navigation { get; private set; }

        protected BaseViewModel(IPageTitleService pageTitleService, ISnackbar snackbar, NavigationManager navigation)
        {
            PageTitleService = pageTitleService;
            Snackbar = snackbar;
            Navigation = navigation;
        }

        protected abstract void UpdateMainTitle();

        protected void ShowSnakbar(string message, Severity type)
        {
           this.Snackbar.Add(message, type);
        }
    }
}
