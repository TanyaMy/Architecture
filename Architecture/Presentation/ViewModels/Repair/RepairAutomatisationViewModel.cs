using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using RepairModel = Architecture.Data.Entities.Repair;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MyToolkit.Utilities;


namespace Architecture.Presentation.ViewModels.Repair
{
    public class RepairAutomatisationViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IRestorationsManager _restorationsManager;
        private readonly IRepairsManager _repairsManager;

        private List<Data.Entities.Architecture> _architectures;
        private List<Data.Entities.Restoration> _restorations;
        private List<RestorationKind> _restorationKindsList;

        private List<ArchitecturesNeedRepairModel> _repairsList;
        private IEnumerable<IGrouping<AutomatisationListItem2, AutomatisationListItem1>> _combinations;

        public RepairAutomatisationViewModel(
           IArchitecturesManager architecturesManager,
           IRestorationsManager restorationsManager,
           IRepairsManager repairsManager)
        {
            _architecturesManager = architecturesManager;
            _restorationsManager = restorationsManager;
            _repairsManager = repairsManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");

            LoadData();

            CalcAutomatisationCommand = new RelayCommand(CalcAutomatisation);
        }

        public ICommand CalcAutomatisationCommand { get; set; }

        public double AvailableSum { get; set; }
        
        public IEnumerable<IGrouping<AutomatisationListItem2, AutomatisationListItem1>> Combinations
        {
            get { return _combinations; }
            set { Set(() => Combinations, ref _combinations, value); }
        }

        public IGrouping<AutomatisationListItem2, AutomatisationListItem1> SelectedCombination { get; set; }

        public async Task SaveCombinationToDatabase()
        {
            foreach (var autoRepairModel in SelectedCombination.Key.Repairs)
            {
                var repair = new Data.Entities.Repair()
                {
                    ArchitectureId = autoRepairModel.ArchitectureId,
                    RestorationCost = autoRepairModel.RepairCost,
                    RestorationKind = autoRepairModel.RestorationKind,
                    RestorationDate = new DateTime(2500, 1, 1)
                };

                await _repairsManager.AddRepair(repair);
            }

            CalcAutomatisation();
        }

        public async Task SaveSingleRepairToDatabase(ArchitecturesNeedRepairModel architecturesNeedRepairModel)
        {
            Data.Entities.Repair repair = new Data.Entities.Repair
            {
                ArchitectureId = architecturesNeedRepairModel.ArchitectureId,
                RestorationCost = architecturesNeedRepairModel.RepairCost,
                RestorationKind = architecturesNeedRepairModel.RestorationKind,
                RestorationDate = new DateTime(2500, 1, 1)
            };

            await SaveSingleRepairToDatabase(repair);
        }

        public async Task SaveSingleRepairToDatabase(Data.Entities.Repair repair)
        {
            repair.RestorationDate = new DateTime(2500, 1, 1);
            await _repairsManager.AddRepair(repair);

            CalcAutomatisation();
        }

        private async void CalcAutomatisation()
        {
            _repairsList = await LoadCombinations();
            _repairsList = _repairsList.Where(x => x.RepairCost <= AvailableSum).OrderByDescending(x => x.RepairCost).ToList();

            var resultList = new List<List<ArchitecturesNeedRepairModel>>();
            var tmpCollection = new List<ArchitecturesNeedRepairModel>();
            for (int i = 0; i < _repairsList.Count; i++)
            {
                tmpCollection = new List<ArchitecturesNeedRepairModel>();
                if (_repairsList[i].RepairCost <= AvailableSum)
                {
                    tmpCollection.Add(_repairsList[i]);
                }

                int holdJPosition = i + 1;

                for (int j = holdJPosition; j < _repairsList.Count; j++)
                {
                    if (tmpCollection.Sum(x => x.RepairCost) + _repairsList[j].RepairCost <= AvailableSum)
                    {
                        tmpCollection.Add(_repairsList[j]);
                    }

                    if (j == _repairsList.Count - 1)
                    {
                        if (tmpCollection.Count > 0)
                        {
                            if (CheckIfContains(resultList, tmpCollection))
                            {
                                continue;
                            }

                            resultList.Add(tmpCollection);
                        }

                        j = holdJPosition++;

                        tmpCollection = new List<ArchitecturesNeedRepairModel> { _repairsList[i] };
                    }
                }
            }
            if (!CheckIfContains(resultList, tmpCollection))
            {
                resultList.Add(tmpCollection);
            }

            int counter = 1;
            Combinations = resultList
                .Select(x => new AutomatisationListItem1 {Key = counter++, ArchitecturesNeedRepairModels = x})
                .GroupBy(x => new AutomatisationListItem2
                    {
                        Count = x.ArchitecturesNeedRepairModels.Count,
                        Total = Convert.ToInt32(x.ArchitecturesNeedRepairModels.Sum(y => y.RepairCost)),
                        Remains = Convert.ToInt32(AvailableSum - x.ArchitecturesNeedRepairModels.Sum(y => y.RepairCost)),
                        Repairs = x.ArchitecturesNeedRepairModels
                    }
                );
        }

        private async void LoadData()
        {
            _architectures = (await _architecturesManager.GetArchitectures()).ToList();
            _restorations = (await _restorationsManager.GetRestorations()).ToList();
            _restorationKindsList = Enum.GetValues(typeof(RestorationKind)).Cast<RestorationKind>().ToList();
        }

        private async Task<List<RestorationKind>> GetRestorationKindByDateandArchId(IList<RepairModel> reps,
            int archId, DateTime restDate)
        {          
            List<RestorationKind> list = new List<RestorationKind>();
            foreach (var r in reps)
                if (r.ArchitectureId != archId && r.RestorationDate != restDate)
                    list.Add(r.RestorationKind);
            return list;
        }

        private async Task<List<ArchitecturesNeedRepairModel>> LoadCombinations()
        {
            var tmpList = new List<ArchitecturesNeedRepairModel>();
            _restorations = (await _restorationsManager.GetRestorations()).ToList();

            var repairs = await _repairsManager.GetRepairs();
            var needRestorationList = _architectures
                .Where(a => (a.State == State.Bad || a.State == State.Awful) 
                  && !repairs.Any(x => x.ArchitectureId == a.Id && x.RestorationDate.Year == 2500
                  && x.RestorationDate > DateTime.Now
                  && GetRestorationKindByDateandArchId(repairs
                  .GetRestorationKindByDateandArchId(repairs, a.Id, x.RestorationDate) 
                  .Contains(x.RestorationKind)))                
                .Select(a => new ArchitecturesNeedRepairModel
                {
                    ArchitectureId = a.Id,
                    ArchitectureTitle = a.Title,
                    ArchitectureState = a.State,
                    Volume = a.Height * a.Square
                }).ToList();

            foreach (var rest in _restorationKindsList)
            {
                var restoration = await _restorationsManager.GetRestorationByRestorationKind(rest);

                if (restoration == null)
                    continue;

                foreach (var arch in needRestorationList)
                {
                    ArchitecturesNeedRepairModel architecture = new ArchitecturesNeedRepairModel();
                    arch.Clone(architecture);

                    architecture.ArchitectureId = arch.ArchitectureId;
                    architecture.RepairCost = Convert.ToInt32(restoration.Outlays * arch.Volume);
                    architecture.RestorationKind = rest;

                    tmpList.Add(architecture);
                }
            }

            return _repairsList = tmpList;
        }

        public bool CheckIfContains<T>(List<List<T>> mainList, List<T> innerList)
        {
            foreach (var el in mainList)
            {
                if ((el.Count >= innerList.Count && el.Except(innerList).Count() == el.Count - innerList.Count)
                 || (el.Count < innerList.Count && innerList.Except(el).Count() == innerList.Count - el.Count))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class ArchitecturesNeedRepairModel
    {
        public int ArchitectureId { get; set; }
        public string ArchitectureTitle { get; set; }
        public State ArchitectureState { get; set; }
        public double Volume { get; set; }
        public int RepairCost { get; set; }
        public RestorationKind RestorationKind { get; set; }
    }

    public class AutomatisationListItem1
    {
        public int Key { get; set; }

        public IList<ArchitecturesNeedRepairModel> ArchitecturesNeedRepairModels { get; set; }
    }

    public class AutomatisationListItem2
    {
        public int Count { get; set; }

        public int Total { get; set; }

        public int Remains { get; set; }

        public IList<ArchitecturesNeedRepairModel> Repairs { get; set; }
    }
}
