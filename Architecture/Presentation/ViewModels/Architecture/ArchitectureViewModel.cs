using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;

        private Type _currentPageType;

        public ArchitectureViewModel()
        {
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectureInternal");
            _customNavigationService.OnPageChanged += CustomNavigationServiceOnOnPageChanged;

            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        private void CustomNavigationServiceOnOnPageChanged(PageKeys pageKey, object @params)
        {
            CurrentInnerPageType = pageKey.GetPageType();
        }

        public ICommand NavTo { get; set; }

        public PageKeys Main => PageKeys.ArchitectureMain;
        public PageKeys Add => PageKeys.ArchitectureAdd;
        public PageKeys Reports => PageKeys.ArchitectureReports;
        public PageKeys Statistics => PageKeys.ArchitectureStatistics;

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
            _customNavigationService.NavigateTo(PageKeys.ArchitectureMain);
        }
    }
}
