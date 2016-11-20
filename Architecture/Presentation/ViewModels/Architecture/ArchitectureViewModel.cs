using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureViewModel : ViewModelBase
    {
        private Type _currentPageType;

        public ArchitectureViewModel()
        {
            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        public ICommand NavTo { get; set; }

        public PageKeys Main => PageKeys.ArchitectureMain;
        public PageKeys Add => PageKeys.ArchitectureAdd;
        public PageKeys Reports => PageKeys.ArchitectureReports;
        public PageKeys Statistics => PageKeys.ArchitectureStatistics;
        public PageKeys Repair => PageKeys.ArchitectureStatistics;

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
            CurrentInnerPageType = PageKeys.ArchitectureMain.GetPageType();
        }
    }
}
