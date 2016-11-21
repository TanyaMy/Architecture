using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Repair
{
    public class RepairViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;

        private Type _currentPageType;

        public RepairViewModel()
        {
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");
            _customNavigationService.OnPageChanged += CustomNavigationServiceOnOnPageChanged;

            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        private void CustomNavigationServiceOnOnPageChanged(PageKeys pageKey, object @params)
        {
            CurrentInnerPageType = pageKey.GetPageType();
        }

        public ICommand NavTo { get; set; }

        public PageKeys Main => PageKeys.RepairMain;
        public PageKeys Add => PageKeys.RepairAdd;
        public PageKeys Automatisation => PageKeys.RepairAutomatisation;
        public PageKeys Restoration => PageKeys.RestorationMain;

        public Type CurrentInnerPageType
        {
            get { return _currentPageType; }
            set { Set(() => CurrentInnerPageType, ref _currentPageType, value); }
        }

        private void NavigateTo(PageKeys pageKey)
        {
            _customNavigationService.NavigateTo(pageKey);
        }

        private void SetDefaultInnerPage()
        {
            _customNavigationService.NavigateTo(PageKeys.RepairMain);
        }
    }
}
