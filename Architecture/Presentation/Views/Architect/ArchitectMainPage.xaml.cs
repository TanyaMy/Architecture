using Architecture.Presentation.ViewModels.Architect;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Architect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArchitectMainPage : Page
    {

        private readonly ArchitectMainViewModel _viewModel;

        public ArchitectMainPage()
        {
            this.InitializeComponent();
            _viewModel = (ArchitectMainViewModel)DataContext;
        }

        private async void SfDataGrid_OnRecordDeleting(object sender, RecordDeletingEventArgs e)
        {
            var itemToDelete = e.Items[0];

            await _viewModel.DeleteArchitect(itemToDelete);
        }

        private async void DeleteRowFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToDelete = _viewModel.SelectedTableItem;

            await _viewModel.DeleteArchitect(itemToDelete);
        }

        private void EditRowMenuFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToEdit = _viewModel.SelectedTableItem;

            _viewModel.EditArchitect(itemToEdit);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            SfDataGrid.ClearFilters();
        }
    }
}
