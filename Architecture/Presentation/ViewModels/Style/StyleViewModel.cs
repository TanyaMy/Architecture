using Arcitecture.Presentation.ViewModels.Common;
using System.Windows.Input;
using System;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using GalaSoft.MvvmLight.Command;

namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleViewModel : ViewModelBase
    {       
        private Type _currentPageType;

        public StyleViewModel()
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
            CurrentInnerPageType = PageKeys.StyleMain.GetPageType();
        }
    }
}
