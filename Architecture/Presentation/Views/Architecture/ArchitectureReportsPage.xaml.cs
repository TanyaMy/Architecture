using System;
using Windows.UI.Xaml.Controls;
using Architecture.Presentation.ViewModels.Architecture;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Architecture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArchitectureReportsPage : Page
    {
        private readonly ArchitectureReportsViewModel _viewModel;
        public ArchitectureReportsPage()
        {
            this.InitializeComponent();

            _viewModel = DataContext as ArchitectureReportsViewModel;
            _viewModel.OnReportTypeChanged += ViewModelOnOnReportTypeChanged;
        }

        private void ViewModelOnOnReportTypeChanged(object collection)
        {
            DataGrid.ItemsSource = collection;
        }
    }
}