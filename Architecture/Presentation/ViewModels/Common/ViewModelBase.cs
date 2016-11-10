using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Command;
using Architecture.Presentation.Models;

namespace Arcitecture.Presentation.ViewModels.Common
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            DialogService = new DialogService();

            GoBackCommand = new RelayCommand(NavigationService.GoBack);
        }

        protected INavigationService NavigationService { get; }

        protected IDialogService DialogService { get; }

        public ICommand GoBackCommand { get; }
    }
}
