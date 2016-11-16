using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleMainViewModel : ViewModelBase
    {
        public class LeftMenuItem
        {
            public SymbolIcon Icon { get; set; }
            public string Text { get; set; }

            public PageKeys InnerPageKey { get; set; }
            public object Params { get; set; }
        }

        private ObservableCollection<LeftMenuItem> _bottomMenuItems;

        private LeftMenuItem _selectedBottomMenuItem;
        private Type _currentPageType;

        public StyleMainViewModel()
        {
            CreateBottomMenuItems();

            SetDefaultSelectedMenuItem();
        }

        public ObservableCollection<LeftMenuItem> BottomMenuItems
        {
            get { return _bottomMenuItems; }
            private set { Set(() => BottomMenuItems, ref _bottomMenuItems, value); }
        }

        public LeftMenuItem SelectedBottomMenuItem
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
            //SelectedBottomMenuItem = _bottomMenuItems.Single(i => i.InnerPageKey == PageKeys.StyleSearch);
        }

        private void CreateBottomMenuItems()
        {
            BottomMenuItems = new ObservableCollection<LeftMenuItem>
            {
                //new LeftMenuItem
                //{
                //    Text = "Поиск",
                //    Icon = new SymbolIcon(Symbol.Find),
                //    InnerPageKey = PageKeys.StyleSearch
                //},
                //new LeftMenuItem
                //{
                //    Text = "Фильтрация",
                //    Icon = new SymbolIcon(Symbol.Filter),
                //    InnerPageKey = PageKeys.StyleFilter
                //},
                //new LeftMenuItem
                //{
                //    Text = "Добавление",
                //    Icon = new SymbolIcon(Symbol.Add),
                //    InnerPageKey = PageKeys.StyleAdd
                //}
            };
        }
    }
}
