using Architecture.Presentation.Models;

namespace Architecture.Presentation.Helpers.Interfaces
{
    public delegate void PageChangedDelegate(PageKeys pageKey, object @params = null);

    public interface ICustomNavigationService
    {
        event PageChangedDelegate OnPageChanged;

        void NavigateTo(PageKeys pageKey, object @params = null);

        PageKeys CurrentPageKey { get; }
        object CurrentPageParams { get; }
    }
}
