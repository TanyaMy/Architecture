using System;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Architect
{
    public class ArchitectViewModel : ViewModelBase
    {
        private Type _currentPageType;

        public ArchitectViewModel()
        {
            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        public ICommand NavTo { get; set; }

        public PageKeys Main => PageKeys.ArchitectMain;
        public PageKeys Add => PageKeys.ArchitectAdd;

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
            CurrentInnerPageType = PageKeys.ArchitectMain.GetPageType();
        }
    }
}
