using System.Windows.Input;
using Architecture.Presentation.Helpers.Interfaces;
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
            CustomNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>();

            DialogService = new DialogService();

            GoBackCommand = new RelayCommand(NavigationService.GoBack);

            PageLoadingCommand = new RelayCommand(OnPageLoading);
            PageLoadedCommand = new RelayCommand(OnPageLoaded);
            PageUnloadedCommand = new RelayCommand(OnPageUnloaded);
        }

        protected ICustomNavigationService CustomNavigationService { get; }

        protected INavigationService NavigationService { get; }

        protected IDialogService DialogService { get; }
        public ICommand PageLoadingCommand { get; }
        public ICommand PageLoadedCommand { get; }
        public ICommand PageUnloadedCommand { get; }

        public ICommand GoBackCommand { get; }

        protected virtual void OnPageLoading()
        {

        }

        protected virtual void OnPageLoaded()
        {

        }

        protected virtual void OnPageUnloaded()
        {

        }
    }
}
