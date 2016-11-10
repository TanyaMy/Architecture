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
    public sealed partial class SourceMainPage : Page
    {
        public SourceMainPage()
        {
            this.InitializeComponent();
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
                    //case "search":
                    //    this.SourceFrame.Navigate(typeof(SourceSearchPage));
                    //    splitView.IsPaneOpen = !splitView.IsPaneOpen;
                    //    break;
                    //case "filter":
                    //    this.SourceFrame.Navigate(typeof(SourceFilterPage));
                    //    splitView.IsPaneOpen = !splitView.IsPaneOpen;
                    //    break;
                    //case "add":
                    //    this.SourceFrame.Navigate(typeof(SourceAddPage));
                    //    splitView.IsPaneOpen = !splitView.IsPaneOpen;
                    //    break;
                }
            }
        }
    }
}
