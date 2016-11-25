using Architecture.Presentation.ViewModels.Source;
using Syncfusion.UI.Xaml.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Source
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SourceMainPage : Page
    {
        private readonly SourceMainViewModel _viewModel;

        public SourceMainPage()
        {
            this.InitializeComponent();

            _viewModel = (SourceMainViewModel)DataContext;
        }

        private async void SfDataGrid_OnRecordDeleting(object sender, RecordDeletingEventArgs e)
        {
            var itemToDelete = e.Items[0];

            await _viewModel.DeleteSource(itemToDelete);
        }

        private async void DeleteRowFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToDelete = _viewModel.SelectedTableItem;

            await _viewModel.DeleteSource(itemToDelete);
        }

        private void EditRowMenuFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToEdit = _viewModel.SelectedTableItem;

            _viewModel.EditSource(itemToEdit);
        }

        private void AddSourceArchFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToAdd = _viewModel.SelectedTableItem;

            _viewModel.AddArchitectureSource(itemToAdd);
        }       
      
    }
}