using Architecture.Presentation.ViewModels.Architect;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


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
            var itemToDelete = e.Items[0] as Data.Entities.Architect;

            if (await Confirm($"Вы уверены, что хотите удалить архитектора {itemToDelete?.Surname}?",
                $"Подтверждение удаления {itemToDelete?.Surname}"))
            {
                await _viewModel.DeleteArchitect(itemToDelete);
            }
        }

        private async void DeleteRowFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToDelete = _viewModel.SelectedTableItem;

            if (!await Confirm($"Вы уверены, что хотите удалить архитектора {itemToDelete.Surname}?",
                "Подтверждение удаления"))
                return;

            await _viewModel.DeleteArchitect(itemToDelete);
        }

        private void EditRowMenuFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToEdit = _viewModel.SelectedTableItem;

            _viewModel.EditArchitect(itemToEdit);
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            SfDataGrid.ClearFilters();
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var selectedValues = SfDataGrid.SelectedItems;
            _viewModel.FilterCollection(SearchTextBox.Text);

            var filteredArchColletion = _viewModel.FilteredArchitectsList;
            var collectionFromSfDataGrid = _viewModel.ArchitectList;

            selectedValues.Clear();

            if (!filteredArchColletion.Any())
                return;

            foreach (var element in collectionFromSfDataGrid.Intersect(filteredArchColletion))
            {
                selectedValues.Add(element);
            }
        }
    }
}
