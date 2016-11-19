using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;

namespace Architecture.Presentation.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public class LeftMenuItem
        {
            public string TextLogo { get; set; }
            public string Text { get; set; }

            public PageKeys InnerPageKey { get; set; }
            public object Params { get; set; }
        }

        private ObservableCollection<LeftMenuItem> _leftMenuItems;

        private LeftMenuItem _selectedLeftMenuItem;
        private Type _currentPageType;
        private bool _isPaneOpened;

        public ShellViewModel()
        {
            CreateLeftMenuItems();

            PaneOpenCloseCommand = new RelayCommand(PaneOpenClose);

            SetDefaultSelectedMenuItem();
        }

        public ICommand PaneOpenCloseCommand { get; }


        public bool IsPaneOpen
        {
            get { return _isPaneOpened; }
            set { Set(() => IsPaneOpen, ref _isPaneOpened, value); }
        }

        public ObservableCollection<LeftMenuItem> LeftMenuItems
        {
            get { return _leftMenuItems; }
            private set { Set(() => LeftMenuItems, ref _leftMenuItems, value); }
        }

        public LeftMenuItem SelectedLeftMenuItem
        {
            get { return _selectedLeftMenuItem; }
            set
            {
                _selectedLeftMenuItem = value;

                IsPaneOpen = false;

                CurrentPageType = value.InnerPageKey.GetPageType();
            }
        }

        public Type CurrentPageType
        {
            get { return _currentPageType; }
            set { Set(() => CurrentPageType, ref _currentPageType, value); }
        }

        private void SetDefaultSelectedMenuItem()
        {
            SelectedLeftMenuItem = _leftMenuItems.Single(i => i.InnerPageKey == PageKeys.Architecture);
        }

        private void PaneOpenClose()
        {
            IsPaneOpen = !_isPaneOpened;
        }

        private void CreateLeftMenuItems()
        {
            LeftMenuItems = new ObservableCollection<LeftMenuItem>
            {
                new LeftMenuItem
                {
                    Text = "Сооружения",
                    TextLogo = "\xE71E",
                    InnerPageKey = PageKeys.Architecture
                },
                new LeftMenuItem
                {
                    Text = "Архитекторы",
                    TextLogo = "\xE71C",
                    InnerPageKey = PageKeys.ArchitectMain
                },
                new LeftMenuItem
                {
                    Text = "Стили",
                    TextLogo = "\xE710",
                    InnerPageKey = PageKeys.StyleMain
                },
                new LeftMenuItem
                {
                    Text = "Упоминания",
                    TextLogo = "\xE8A5",
                    InnerPageKey = PageKeys.SourceMain
                }
            };
        }
    }
}