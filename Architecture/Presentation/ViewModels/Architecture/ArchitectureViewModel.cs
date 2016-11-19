using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureViewModel : ViewModelBase
    {

        public class BottomMenuItem
        {
            public SymbolIcon Icon { get; set; }
            public string Text { get; set; }

            public PageKeys InnerPageKey { get; set; }
            public object Params { get; set; }
        }

        private ObservableCollection<BottomMenuItem> _bottomMenuItems;

        private BottomMenuItem _selectedBottomMenuItem;
        private Type _currentPageType;

        public ArchitectureViewModel()
        {
            CreateBottomMenuItems();

            SetDefaultSelectedMenuItem();
        }

        public ObservableCollection<BottomMenuItem> BottomMenuItems
        {
            get { return _bottomMenuItems; }
            private set { Set(() => BottomMenuItems, ref _bottomMenuItems, value); }
        }

        public BottomMenuItem SelectedBottomMenuItem
        {
            get { return _selectedBottomMenuItem; }
            set
            {
                _selectedBottomMenuItem = value;
                
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
            SelectedBottomMenuItem = _bottomMenuItems.Single(i => i.InnerPageKey == PageKeys.ArchitectureMain);
        }

        private void CreateBottomMenuItems()
        {
            BottomMenuItems = new ObservableCollection<BottomMenuItem>
            {
                new BottomMenuItem
                {
                    Text = "Главная",
                    Icon = new SymbolIcon(Symbol.Home),
                    InnerPageKey = PageKeys.ArchitectureMain
                },
                new BottomMenuItem
                {
                    Text = "Добавление",
                    Icon = new SymbolIcon(Symbol.Add),
                    InnerPageKey = PageKeys.ArchitectureAdd
                },
                new BottomMenuItem
                {
                    Text = "Отчеты",
                    Icon = new SymbolIcon(Symbol.Document),

                    //TODO: Set correct page
                    InnerPageKey = PageKeys.ArchitectureReports
                },
                new BottomMenuItem
                {
                    Text = "Статистика",
                    Icon = new SymbolIcon(Symbol.List),

                    //TODO: Set correct page
                    InnerPageKey = PageKeys.ArchitectureStatistics
                },
                new BottomMenuItem
                {
                    Text = "Ремонт",
                    Icon = new SymbolIcon(Symbol.Repair),

                    //TODO: Set correct page
                    InnerPageKey = PageKeys.ArchitectureStatistics
                }
            };
        }
    }
}
