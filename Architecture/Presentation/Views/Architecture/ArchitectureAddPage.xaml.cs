using Windows.UI.Xaml.Controls;
using Architecture.Presentation.ViewModels.Architecture;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Architecture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArchitectureAddPage : Page
    {
        private readonly ArchitectureAddViewModel _viewModel;

        public ArchitectureAddPage()
        {
            this.InitializeComponent();

            _viewModel = (ArchitectureAddViewModel) DataContext;
        }

        private void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            _viewModel.FilterStylesForAutosuggest(sender.Text);
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            _viewModel.FilterStylesForAutosuggest("");
            _viewModel.Style = (Data.Entities.Style) args.SelectedItem;
            sender.Text = _viewModel.Style.Title;
            sender.UpdateTextOnSelect = false;
        }
    }
}
