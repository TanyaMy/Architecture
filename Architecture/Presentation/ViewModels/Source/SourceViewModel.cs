using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Source
{
    public class SourceViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;

        private Type _currentPageType;

        public SourceViewModel()
        {
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("SourceInternal");
            _customNavigationService.OnPageChanged += CustomNavigationServiceOnOnPageChanged;

            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        private void CustomNavigationServiceOnOnPageChanged(PageKeys pageKey, object @params)
        {
            CurrentInnerPageType = pageKey.GetPageType();
        }

        public ICommand NavTo { get; set; }

        public PageKeys Main => PageKeys.SourceMain;
        public PageKeys Add => PageKeys.SourceAdd;

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
