using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Architecture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArchitectureMainPage : Page
    {
        public ArchitectureMainPage()
        {
            this.InitializeComponent();
            this.ArchitectureFrame.Navigate(typeof(ArchitectureSearchPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void RadioButtonPaneItem_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton != null)
            {
                switch (radioButton.Tag.ToString())
                {
                    case "search":
                        this.ArchitectureFrame.Navigate(typeof(ArchitectureSearchPage));
                        splitView.IsPaneOpen = !splitView.IsPaneOpen;
                        break;
                    case "filter":
                        this.ArchitectureFrame.Navigate(typeof(ArchitectureFilterPage));
                        splitView.IsPaneOpen = !splitView.IsPaneOpen;
                        break;
                    case "add":
                        this.ArchitectureFrame.Navigate(typeof(ArchitectureAddPage));
                        splitView.IsPaneOpen = !splitView.IsPaneOpen;
                        break;
                    case "reports":
                        this.ArchitectureFrame.Navigate(typeof(ArchitectureReportsPage));
                        splitView.IsPaneOpen = !splitView.IsPaneOpen;
                        break;
                }
            }
        }
    }
}