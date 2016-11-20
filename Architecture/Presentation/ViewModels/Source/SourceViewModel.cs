using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Source
{
    public class SourceViewModel : ViewModelBase
    {
        private Type _currentPageType;

        public SourceViewModel()
        {
            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        public ICommand NavTo { get; set; }

        public PageKeys Main => PageKeys.StyleMain;
        public PageKeys Add => PageKeys.StyleAdd;

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
            CurrentInnerPageType = PageKeys.SourceMain.GetPageType();
        }
    }
}
