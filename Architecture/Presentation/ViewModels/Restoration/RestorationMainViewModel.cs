using System.Linq;
using Arcitecture.Presentation.ViewModels.Common;
using RestorationModel = Architecture.Data.Entities.Restoration;
using Architecture.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Presentation.Helpers.Interfaces;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using Architecture.Presentation.Models;

namespace Architecture.Presentation.ViewModels.Restoration
{
    public class RestorationMainViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRestorationsManager _restorationsManager;

        private ObservableCollection<RestorationModel> _restorations;
        private RestorationModel _selectedTableItem;

        public RestorationMainViewModel(IRestorationsManager restorationsManager)
        {
            _restorationsManager = restorationsManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");

            LoadData();
        }

        public ObservableCollection<RestorationModel> RestorationList
        {
            get { return _restorations; }
            set { Set(() => RestorationList, ref _restorations, value); }
        }       

        public RestorationModel SelectedTableItem
        {
            get { return _selectedTableItem; }
            set { Set(() => SelectedTableItem, ref _selectedTableItem, value); }
        }

        public void EditRestoration(RestorationModel itemToEdit)
        {
            _customNavigationService.NavigateTo(PageKeys.RestorationUpdate, itemToEdit);
        }

        private async void LoadData()
        {
            RestorationList = new ObservableCollection<RestorationModel>(await _restorationsManager.GetRestorations());
        }
    }
}
