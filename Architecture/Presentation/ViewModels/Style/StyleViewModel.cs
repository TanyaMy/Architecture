using Arcitecture.Presentation.ViewModels.Common;
using System.Windows.Input;
using System;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using GalaSoft.MvvmLight.Command;
using Architecture.Presentation.Helpers.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;

        private Type _currentPageType;

        public StyleViewModel()
        {
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("StyleInternal");
            _customNavigationService.OnPageChanged += CustomNavigationServiceOnOnPageChanged;

            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        private void CustomNavigationServiceOnOnPageChanged(PageKeys pageKey, object @params)
        {
            CurrentInnerPageType = pageKey.GetPageType();
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
            _customNavigationService.NavigateTo(pageKey);
        }

        private void SetDefaultInnerPage()
        {
            _customNavigationService.NavigateTo(PageKeys.StyleMain);
        }
    }
}
