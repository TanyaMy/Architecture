using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
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

            _viewModel = (ArchitectureMainViewModel) DataContext;
        }

        private async void SfDataGrid_OnRecordDeleting(object sender, RecordDeletingEventArgs e)
        {
            var itemToDelete = e.Items[0] as Data.Entities.Architecture;
            if (await Confirm($"Вы уверены, что хотите удалить архитектурное сооружение {itemToDelete?.Title}?",
                $"Подтверждение удаления {itemToDelete?.Title}"))
            {
                await _viewModel.DeleteArchitecture(itemToDelete);
            }
        }

        private async void DeleteRowFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToDelete = _viewModel.SelectedTableItem;
            if (!await Confirm($"Вы уверены, что хотите удалить архитектурное сооружение {itemToDelete.Title}?",
                "Подтверждение удаления"))
                return;

            await _viewModel.DeleteArchitecture(itemToDelete);
        }

        private void EditRowMenuFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToEdit = _viewModel.SelectedTableItem;

            _viewModel.EditArchitecture(itemToEdit);
        }

        private async Task<bool> Confirm(string message, string title)
        {
            bool answer = false;

            MessageDialog msgDialog = new MessageDialog(message, title);

            //OK Button
            UICommand okBtn = new UICommand("OK") {Invoked = command => answer = true};
            msgDialog.Commands.Add(okBtn);

            //Cancel Button
            UICommand cancelBtn = new UICommand("Cancel") {Invoked = command => answer = false};
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
            
            var filteredArchColletion = _viewModel.FilteredArchitecturesList;
            var collectionFromSfDataGrid = _viewModel.ArchitectureList;
            
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