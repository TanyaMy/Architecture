using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Repair
{
    public class RepairAddViewModel : ViewModelBase
    {
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IRestorationsManager _restorationsManager;
        private readonly IRepairsManager _repairsManager;

        private List<Data.Entities.Architecture> _architecturesList;
        private List<Data.Entities.Restoration> _restorationsList;

        private Data.Entities.Architecture _architecture;
        private RestorationKind _restorationKind;
        private DateTime _restorationDate;
        private double _restorationCost;


        public RepairAddViewModel(
           IArchitecturesManager architecturesManager,
           IRestorationsManager restorationsManager,
           IRepairsManager repairsManager)
        {
            _architecturesManager = architecturesManager;
            _restorationsManager = restorationsManager;
            _repairsManager = repairsManager;

            SaveCommand = new RelayCommand(async () => await SaveToDb());

            InitData();
        }

        private async void InitData()
        {
            RestorationKindsList = Enum.GetValues(typeof(RestorationKind)).Cast<RestorationKind>().ToList();

            ArchitecturesList = (await _architecturesManager.GetArchitectures()).ToList();

            RestorationsList = (await _restorationsManager.GetRestorations()).ToList();
        }

        public ICommand SaveCommand { get; }

        public List<RestorationKind> RestorationKindsList { get; private set; }

        public List<Data.Entities.Architecture> ArchitecturesList
        {
            get { return _architecturesList; }
            set { Set(() => ArchitecturesList, ref _architecturesList, value); }
        }

        public List<Data.Entities.Restoration> RestorationsList
        {
            get { return _restorationsList; }
            set { Set(() => RestorationsList, ref _restorationsList, value); }
        }

        public RestorationKind RestorationKind
        {
            get { return _restorationKind; }
            set { Set(() => RestorationKind, ref _restorationKind, value); }
        }

        public Data.Entities.Architecture Architecture
        {
            get { return _architecture; }
            set { Set(() => Architecture, ref _architecture, value); }
        }

        public DateTime RestorationDate
        {
            get { return _restorationDate; }
            set { Set(() => RestorationDate, ref _restorationDate, value); }
        }

        public double RestorationCost
        {
            get { return _restorationCost; }
            set { Set(() => RestorationCost, ref _restorationCost, value); }
        }      

        

        private async Task SaveToDb()
        {
            var repair = new Data.Entities.Repair(RestorationKind,
                Architecture.Id, RestorationDate, RestorationCost);

            await _repairsManager.AddRepair(repair);
        }
    }
}
