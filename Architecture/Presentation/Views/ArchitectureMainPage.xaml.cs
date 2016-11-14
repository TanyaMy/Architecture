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

namespace Architecture.Presentation.Views
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
