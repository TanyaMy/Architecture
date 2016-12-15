using Architecture.Presentation.ViewModels.Repair;
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

namespace Architecture.Presentation.Views.Repair
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RepairAutomatisationPage : Page
    {
        private readonly RepairAutomatisationViewModel _viewModel;

        public RepairAutomatisationPage()
        {
            this.InitializeComponent();

            _viewModel = (RepairAutomatisationViewModel)DataContext;
        }
        
        private async void SaveCombination_OnClick(object sender, RoutedEventArgs e)
        {
            await _viewModel.SaveCombinationToDatabase();
        }

        private async void SaveSingle_OnClick(object sender, RoutedEventArgs e)
        {
            await _viewModel.SaveSingleRepairToDatabase();
        }
    }
}
