using Architecture.Presentation.ViewModels.Repair;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Repair
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RepairAddPage : Page
    {
        private readonly RepairAddViewModel _viewModel;

        public RepairAddPage()
        {
            this.InitializeComponent();

            _viewModel = (RepairAddViewModel)DataContext;
        }

        private void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            _viewModel.FilterArchitecturesForAutosuggest(sender.Text);
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            _viewModel.FilterArchitecturesForAutosuggest("");
            _viewModel.Architecture = (Data.Entities.Architecture)args.SelectedItem;
            sender.Text = _viewModel.Architecture.Title;
            sender.UpdateTextOnSelect = false;
        }
    }
}
