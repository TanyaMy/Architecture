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

        private void AutoSuggestBox_OnTextChangedStyles(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            _viewModel.FilterStylesForAutosuggest(sender.Text);
        }

        private void AutoSuggestBox_OnTextChangedArchitects(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            _viewModel.FilterArchitectsForAutosuggest(sender.Text);
        }

        private void AutoSuggestBox_SuggestionChosenStyle(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            _viewModel.FilterStylesForAutosuggest("");
            _viewModel.Style = (Data.Entities.Style) args.SelectedItem;
            sender.Text = _viewModel.Style.Title;
            sender.UpdateTextOnSelect = false;
        }

        private void AutoSuggestBox_SuggestionChosenArchitect(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            _viewModel.FilterArchitectsForAutosuggest("");
            _viewModel.Architect = (Data.Entities.Architect)args.SelectedItem;
            sender.Text = _viewModel.Architect.Surname;
            sender.UpdateTextOnSelect = false;
        }
    }
}
