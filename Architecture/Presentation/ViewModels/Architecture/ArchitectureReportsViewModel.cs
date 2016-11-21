using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using RepairModel = Architecture.Data.Entities.Repair;
using ArchitectureModel = Architecture.Data.Entities.Architecture;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureReportsViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRepairsManager _repairsManager;
        private readonly IArchitecturesManager _architecturesManager;

        private List<RepairModel> _repairs;
        private List<ArchitectureModel> _architectures;

        public ArchitectureReportsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager)
        {
            _repairsManager = repairsManager;
            _architecturesManager = architecturesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");

            LoadData();
        }

        public List<RepairModel> RepairList
        {
            get { return _repairs; }
            set { Set(() => RepairList, ref _repairs, value); }
        }

        public List<ArchitectureModel> ArchitectureOldList
        {
            get { return _architectures; }
            set { Set(() => ArchitectureOldList, ref _architectures, value); }
        }

        public List<ArchitectureModel> ArchitectureStateList
        {
            get { return _architectures; }
            set { Set(() => ArchitectureOldList, ref _architectures, value); }
        }

        private async void LoadData()
        {
            //вид реставрации, название сооружения, дата ремонта не ранее 2006, затраты ремонта
            //
            //название сооружения, дата создания ранее 1800 года в порядке возрастания
            //
            // название сооружения, его состояние
            //

            ArchitectureOldList = _architectures.Where(a => a.CreationYear < 1800).ToList();

            ArchitectureStateList = new List<ArchitectureModel>(await _architecturesManager.GetArchitectures());

            RepairList = _repairs.Where(r => r.RestorationDate > DateTime.Now.AddYears(-10)).ToList();
        }
    }
}
