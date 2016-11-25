using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Architecture.Presentation.Views.Architect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArchitectAddPage : Page
    {
        public ArchitectAddPage()
        {
            this.InitializeComponent();
            birthDtp.MaxYear = DateTime.Now;
            deathDtp.MaxYear = DateTime.Now;
            birthDtp.MinYear = DateTime.Now.AddYears(-2006);
            deathDtp.MinYear = DateTime.Now.AddYears(-2006);
        }

        
    }
}
