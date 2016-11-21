using System.Linq;
using Arcitecture.Presentation.ViewModels.Common;
using StyleModel = Architecture.Data.Entities.Style;
using Architecture.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Presentation.Helpers.Interfaces;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using Architecture.Presentation.Models;

namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleMainViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IStylesManager _stylesManager;

        private ObservableCollection<StyleModel> _styles;
        private StyleModel _selectedTableItem;

        public StyleMainViewModel(IStylesManager stylesManager)
        {
            _stylesManager = stylesManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("StyleInternal");

            LoadData();
        }

        public ObservableCollection<StyleModel> StyleList
        {
            get { return _styles; }
            set { Set(() => StyleList, ref _styles, value); }
        }

        public StyleModel SelectedTableItem
        {
            get { return _selectedTableItem; }
            set { Set(() => SelectedTableItem, ref _selectedTableItem, value); }
        }

        public void EditStyle(StyleModel itemToEdit)
        {
            _customNavigationService.NavigateTo(PageKeys.StyleAdd, itemToEdit);
        }

        public async Task DeleteStyle(object style)
        {
            var styl = style as StyleModel;

            if (styl == null)
                return;

            await _stylesManager.RemoveStyle(styl.Id);

            StyleList.Remove(styl);
        }

        private async void LoadData()
        {
            StyleList = new ObservableCollection<StyleModel>(await _stylesManager.GetStyles());
        }
    }
}
