using GalaSoft.MvvmLight.Command;
using Architecture.Presentation.Models;
using System.Windows.Input;
using Arcitecture.Presentation.ViewModels.Common;

namespace Architecture.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {

            GoToArchitecturePageCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.ArchitectureMain));
            GoToArchitectPageCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.ArchitectMain));
            GoToStylePageCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.StyleMain));
            GoToSourcePageCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.SourceMain));
            GoToRestorationPageCommand = new RelayCommand(() => NavigationService.NavigateTo(PageKeys.RestorationMain));
        }

        public ICommand GoToArchitecturePageCommand { get; }

        public ICommand GoToArchitectPageCommand { get; }

        public ICommand GoToStylePageCommand { get; }

        public ICommand GoToSourcePageCommand { get; }

        public ICommand GoToRestorationPageCommand { get; }
    }
}
