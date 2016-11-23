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
using System.Threading.Tasks;
using System.Windows.Input;
using RepairModel = Architecture.Data.Entities.Repair;


namespace Architecture.Presentation.ViewModels.Repair
{
    public class RepairAutomatisationViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IRestorationsManager _restorationsManager;

        private List<Data.Entities.Architecture> _architectures;
        private List<Data.Entities.Restoration> _restorations;
        private List<RestorationKind> _restorationKindsList;

        private List<ArchitecturesNeedRepairModel> _repairsList;

        public RepairAutomatisationViewModel(
           IArchitecturesManager architecturesManager,
           IRestorationsManager restorationsManager)
        {
            _architecturesManager = architecturesManager;
            _restorationsManager = restorationsManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");         

            LoadData();
        }

        public List<ArchitecturesNeedRepairModel> RepairsList
        {
            get { return _repairsList; }
            set { Set(() => RepairsList, ref _repairsList, value); }
        }        

        private async void LoadData()
        {

            _architectures = (await _architecturesManager.GetArchitectures()).ToList();
            _restorations = (await _restorationsManager.GetRestorations()).ToList();
            _restorationKindsList = Enum.GetValues(typeof(RestorationKind)).Cast<RestorationKind>().ToList();

            var tmpList = new List<ArchitecturesNeedRepairModel>();

            var needRestorationList = _architectures.Where(a => a.State == State.Bad || a.State == State.Awful)
                .Select(a => new ArchitecturesNeedRepairModel
                {
                    ArchitectureTitle = a.Title,
                    ArchitectureState = a.State,
                    Volume = a.Height * a.Square
                }).ToList();

            ArchitecturesNeedRepairModel tmpArch = new ArchitecturesNeedRepairModel();
            Data.Entities.Restoration restoration = new Data.Entities.Restoration();

            foreach (var rest in _restorationKindsList)
            {
                foreach (var arch in needRestorationList)
                {
                    arch.ArchitectureId = (tmpList.Count == 0) ? 1 : tmpList.Max(a => a.ArchitectureId) + 1;
                    restoration = await _restorationsManager.GetRestorationByRestorationKind(rest);
                    arch.RepairCost = restoration.Outlays * arch.Volume;
                    arch.RestorationKind = rest;
                    tmpList.Add(arch);
                }                
            }

            RepairsList = tmpList;
        }
    }

    public class ArchitecturesNeedRepairModel
    {
        public int ArchitectureId { get; set; }
        public string ArchitectureTitle { get; set; }
        public State ArchitectureState { get; set; }
        public double Volume { get; set; }
        public double RepairCost { get; set; }
        public RestorationKind RestorationKind { get; set; }
    }    
}
