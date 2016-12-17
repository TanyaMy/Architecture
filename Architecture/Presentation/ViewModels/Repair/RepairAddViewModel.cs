using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using RepairModel = Architecture.Data.Entities.Repair;

namespace Architecture.Presentation.ViewModels.Repair
{
    public class RepairAddViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IRestorationsManager _restorationsManager;
        private readonly IRepairsManager _repairsManager;

        private List<Data.Entities.Architecture> _architecturesList;
        private List<Data.Entities.Restoration> _restorationsList;

        private readonly RepairModel _repair;

        private Data.Entities.Architecture _architecture;
        private RestorationKind _restorationKind;
        private DateTimeOffset _restorationDate;
        private double _restorationCost;
        private readonly bool _isAddingMode;


        public RepairAddViewModel(
           IArchitecturesManager architecturesManager,
           IRestorationsManager restorationsManager,
           IRepairsManager repairsManager)
        {
            _architecturesManager = architecturesManager;
            _restorationsManager = restorationsManager;
            _repairsManager = repairsManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");

            _repair = _customNavigationService.CurrentPageParams as RepairModel;

            _isAddingMode = _repair == null;

            SaveCommand = _isAddingMode
                ? new RelayCommand(AddRepair)
                : new RelayCommand(UpdateRepair);

            ActionText = _isAddingMode ? "Добавление" : "Редактирование";
            ButtonText = _isAddingMode ? "Добавить" : "Сохранить изменения";

            InitData();
            SetupFields();
        }

        private async void InitData()
        {
            RestorationKindsList = Enum.GetValues(typeof(RestorationKind)).Cast<RestorationKind>().ToList();

            ArchitecturesList = (await _architecturesManager.GetArchitectures()).ToList();

            RestorationsList = (await _restorationsManager.GetRestorations()).ToList();
        }

        public ICommand SaveCommand { get; }

        public string ActionText { get; }
        public string ButtonText { get; }

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

        public DateTimeOffset RestorationDate
        {
            get { return _restorationDate; }
            set { Set(() => RestorationDate, ref _restorationDate, value); }
        }

        public double RestorationCost
        {
            get { return _restorationCost; }
            set { Set(() => RestorationCost, ref _restorationCost, value); }
        }

        public bool IsAddingMode => _isAddingMode;

        private async void AddRepair()
        {
            var repair = new RepairModel(RestorationKind, 
                Architecture.Id, RestorationDate.DateTime.Date, RestorationCost);

            await _repairsManager.AddRepair(repair);

            _customNavigationService.NavigateTo(PageKeys.RepairMain);
        }

        private async void UpdateRepair()
        {
            var repair =
                await _repairsManager.GetRepairById(Architecture.Id, RestorationKind, RestorationDate.DateTime.Date);

            repair.RestorationCost = RestorationCost;

            await _repairsManager.UpdateRepair(repair);
            
            _customNavigationService.NavigateTo(PageKeys.RepairMain);
        }

        private void SetupFields()
        {
            RepairModel editableRep = _repair;
                    
            RestorationKind = editableRep?.RestorationKind ?? RestorationKind.Косметическая;
            Architecture = editableRep?.Architecture ?? null;
            RestorationDate = editableRep?.RestorationDate ?? DateTime.Now;
            RestorationCost = editableRep?.RestorationCost ?? 0;
        }
    }
}
