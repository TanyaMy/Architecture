using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Architecture.Presentation.ViewModels.Architecture;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Architecture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArchitectureMainPage : Page
    {

        private readonly ArchitectureMainViewModel _viewModel;

        public ArchitectureMainPage()
        {
            this.InitializeComponent();

            _viewModel = (ArchitectureMainViewModel)DataContext;
        }

        private async void SfDataGrid_OnRecordDeleting(object sender, RecordDeletingEventArgs e)
        {
            var itemToDelete = e.Items[0];

            await _viewModel.DeleteArchitecture(itemToDelete);
        }

        private async void DeleteRowFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToDelete = _viewModel.SelectedTableItem;

            await _viewModel.DeleteArchitecture(itemToDelete);
        }

        private void EditRowMenuFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToEdit = _viewModel.SelectedTableItem;

            _viewModel.EditArchitecture(itemToEdit);
        }
    }
}