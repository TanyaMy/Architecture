using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;

namespace Architecture.Presentation.Helpers.Implementations
{
    class CustomNavigationService : ICustomNavigationService
    {
        private NavigationPageHelper _pagePair;

        private class NavigationPageHelper
        {
            public NavigationPageHelper(PageKeys pageKey, object @params = null)
            {
                PageKey = pageKey;
                Params = @params;
            }

            public PageKeys PageKey { get; }

            public object Params { get; }
        }

        public CustomNavigationService()
        {   
            _pagePair = new NavigationPageHelper(PageKeys.ArchitectMain);
        }

        public event PageChangedDelegate OnPageChanged;

        public void NavigateTo(PageKeys pageKey, object @params = null)
        {
            _pagePair = new NavigationPageHelper(pageKey, @params);

            OnPageChanged?.Invoke(pageKey, pageKey);
        }

        public PageKeys CurrentPageKey => _pagePair.PageKey;
        public object CurrentPageParams => _pagePair?.Params;
    }
}
