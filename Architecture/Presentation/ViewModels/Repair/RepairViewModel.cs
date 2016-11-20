using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Repair
{
    public class RepairViewModel : ViewModelBase
    {

        private Type _currentPageType;

        public RepairViewModel()
        {
            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
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
            CurrentInnerPageType = pageKey.GetPageType();
        }

        private void SetDefaultInnerPage()
        {
            CurrentInnerPageType = PageKeys.RepairMain.GetPageType();
        }
    }
}
