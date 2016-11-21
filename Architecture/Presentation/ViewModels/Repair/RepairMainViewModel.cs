using System.Linq;
using Arcitecture.Presentation.ViewModels.Common;
using RepairModel = Architecture.Data.Entities.Repair;
using Architecture.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Presentation.Helpers.Interfaces;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using Architecture.Presentation.Models;

namespace Architecture.Presentation.ViewModels.Repair
{
    public class RepairMainViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRepairsManager _repairsManager;

        private ObservableCollection<RepairModel> _repairs;
        private RepairModel _selectedTableItem;

        public RepairMainViewModel(IRepairsManager repairsManager)
        {
            _repairsManager = repairsManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");

            LoadData();
        }

        public ObservableCollection<RepairModel> RepairList
        {
            get { return _repairs; }
            set { Set(() => RepairList, ref _repairs, value); }
        }

        public RepairModel SelectedTableItem
        {
            get { return _selectedTableItem; }
            set { Set(() => SelectedTableItem, ref _selectedTableItem, value); }
        }

        public void EditRepair(RepairModel itemToEdit)
        {
            _customNavigationService.NavigateTo(PageKeys.RepairAdd, itemToEdit);
        }

        public async Task DeleteRepair(object repair)
        {
            var rep = repair as RepairModel;

            if (rep == null)
                return;

            await _repairsManager.RemoveRepair(rep.ArchitectureId, rep.RestorationKind);

            RepairList.Remove(rep);
        }

        private async void LoadData()
        {
            RepairList = new ObservableCollection<RepairModel>(await _repairsManager.GetRepairs());
        }
    }
}
