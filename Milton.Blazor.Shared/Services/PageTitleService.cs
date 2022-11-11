using Milton.Blazor.Shared.Interfaces;

namespace Milton.Blazor.Shared.Services
{
    public class PageTitleService : IPageTitleService
    {
        public string MainTitle
        #region
        {
            get => _mainTitle;
            set
            {
                if (_mainTitle != value)
                {
                    _mainTitle = value;
                    InvokeOnTitleChanged();
                }
            }
        }
        private string _mainTitle;
        #endregion

        public string SubTitle
        #region
        {
            get => _subTitle;
            set
            {
                if (_subTitle != value)
                {
                    _subTitle = value;
                    InvokeOnTitleChanged();
                }
            }
        }
        private string _subTitle;
        #endregion

        public event Action OnTitleChanged;
        public void InvokeOnTitleChanged()
        {
            OnTitleChanged?.Invoke();
        }
    }
}
