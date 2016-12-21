using System;
using Windows.UI.Xaml.Controls;
using Architecture.Presentation.ViewModels.Architecture;
using Windows.UI.Xaml;
using Syncfusion.UI.Xaml.Grid;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Architecture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArchitectureReportsPage : Page
    {
      
        public ArchitectureReportsPage()
        {
            this.InitializeComponent();            
        }

        private void PrintButton_OnClick(object sender, RoutedEventArgs e)
        {
            SfDataGrid.PrintSettings.PrintScaleOption = PrintScaleOptions.FitAllColumnsonOnePage;
            SfDataGrid.PrintSettings.AllowColumnWidthFitToPrintPage = true;
            SfDataGrid.PrintSettings.AllowRepeatHeaders = true;

            SfDataGrid.Print();
        }
    }
}