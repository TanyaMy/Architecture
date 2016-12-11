using Architecture.Presentation.ViewModels.Repair;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Repair
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RepairMainPage : Page
    {
        private readonly RepairMainViewModel _viewModel;

        public RepairMainPage()
        {
            this.InitializeComponent();

            _viewModel = (RepairMainViewModel)DataContext;
        }

        private async void SfDataGrid_OnRecordDeleting(object sender, RecordDeletingEventArgs e)
        {
            var itemToDelete = e.Items[0] as Data.Entities.Repair;


            if (await Confirm($"Вы уверены, что хотите удалить реставрацию {itemToDelete?.RestorationKind} для сооружения {itemToDelete?.Architecture.Title}?",
                $"Подтверждение удаления {itemToDelete?.RestorationKind}"))
            {
                await _viewModel.DeleteRepair(itemToDelete);
            }
        }

        private async void DeleteRowFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToDelete = _viewModel.SelectedTableItem;

            if (!await Confirm($"Вы уверены, что хотите удалить реставрацию {itemToDelete?.RestorationKind} для сооружения {itemToDelete?.Architecture.Title}?",
                "Подтверждение удаления"))
                return;

            await _viewModel.DeleteRepair(itemToDelete);
        }

        private void EditRowMenuFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToEdit = _viewModel.SelectedTableItem;

            _viewModel.EditRepair(itemToEdit);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            SfDataGrid.ClearFilters();
        }

        private async Task<bool> Confirm(string message, string title)
        {
            bool answer = false;

            MessageDialog msgDialog = new MessageDialog(message, title);

            //OK Button
            UICommand okBtn = new UICommand("OK") { Invoked = command => answer = true };
            msgDialog.Commands.Add(okBtn);

            //Cancel Button
            UICommand cancelBtn = new UICommand("Cancel") { Invoked = command => answer = false };
            msgDialog.Commands.Add(cancelBtn);

            await msgDialog.ShowAsync();
            return answer;
        }
    }
}
