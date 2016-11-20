using Windows.UI.Xaml.Controls;
using Architecture.Presentation.ViewModels.Architecture;
using Syncfusion.UI.Xaml.Grid;

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
    }
}