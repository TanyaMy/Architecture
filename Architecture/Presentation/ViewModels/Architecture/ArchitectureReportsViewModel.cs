using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using RepairModel = Architecture.Data.Entities.Repair;
using ArchitectureModel = Architecture.Data.Entities.Architecture;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureReportsViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRepairsManager _repairsManager;
        private readonly IArchitecturesManager _architecturesManager;

        private ObservableCollection<RepairModel> _repairs;
        private ObservableCollection<ArchitectureModel> _architectures;

        public ArchitectureReportsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager)
        {
            _repairsManager = repairsManager;
            _architecturesManager = architecturesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");

            LoadData();
        }

        public ObservableCollection<RepairModel> RepairList
        {
            get { return _repairs; }
            set { Set(() => RepairList, ref _repairs, value); }
        }

        public ObservableCollection<ArchitectureModel> ArchitectureList
        {
            get { return _architectures; }
            set { Set(() => ArchitectureList, ref _architectures, value); }
        }

        private async void LoadData()
        {
            //вид реставрации, название сооружения, дата ремонта не ранее 2006, затраты ремонта
            //_architecturesManager.GetArchitectures().
            //название сооружения, дата создания ранее 1800 года в порядке возрастания
            //
            // название сооружения, его состояние
            //

            ArchitectureList = new ObservableCollection<ArchitectureModel>(await _architecturesManager.GetArchitectures());            

            RepairList = new ObservableCollection<RepairModel>(await _repairsManager.GetRepairs());
        }
    }
}
