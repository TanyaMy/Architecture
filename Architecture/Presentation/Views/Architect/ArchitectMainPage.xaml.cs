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
        public ArchitectMainPage()
        {
            this.InitializeComponent();
            this.ArchitectFrame.Navigate(typeof(ArchitectSearchPage));
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
                        this.ArchitectFrame.Navigate(typeof(ArchitectSearchPage));
                        splitView.IsPaneOpen = !splitView.IsPaneOpen;
                        break;
                    case "filter":
                        this.ArchitectFrame.Navigate(typeof(ArchitectFilterPage));
                        splitView.IsPaneOpen = !splitView.IsPaneOpen;
                        break;
                    case "add":
                        this.ArchitectFrame.Navigate(typeof(Architect.ArchitectAddPage));
                        splitView.IsPaneOpen = !splitView.IsPaneOpen;
                        break;
                }
            }
        }
    }
}
