using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
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

            LoadCombinations();

            CalcAutomatisationCommand = new RelayCommand(CalcAutomatisation);
        }

        public ICommand CalcAutomatisationCommand { get; set; }

        public double AvailableSum { get; set; }

        public List<ArchitecturesNeedRepairModel> RepairsList
        {
            get { return _repairsList; }
            set { Set(() => RepairsList, ref _repairsList, value); }
        }

        private async void CalcAutomatisation()
        {
            RepairsList = await LoadCombinations();
            RepairsList = RepairsList.Where(x => x.RepairCost <= AvailableSum).OrderByDescending(x => x.RepairCost).ToList();

            var resultList = new List<List<ArchitecturesNeedRepairModel>>();
            var tmpCollection = new List<ArchitecturesNeedRepairModel>();
            for (int i = 0; i < RepairsList.Count; i++)
            {
                tmpCollection = new List<ArchitecturesNeedRepairModel>();
                if (RepairsList[i].RepairCost <= AvailableSum)
                {
                    tmpCollection.Add(RepairsList[i]);
                }

                int holdJPosition = i + 1;

                for (int j = holdJPosition; j < RepairsList.Count; j++)
                {
                    if (tmpCollection.Sum(x => x.RepairCost) + RepairsList[j].RepairCost <= AvailableSum)
                    {
                        tmpCollection.Add(RepairsList[j]);
                    }

                    if (j == RepairsList.Count - 1)
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

                        tmpCollection = new List<ArchitecturesNeedRepairModel> { RepairsList[i] };
                    }
                }
            }
            if (!CheckIfContains(resultList, tmpCollection))
            {
                resultList.Add(tmpCollection);
            }


            var xxx = new List<ArchitecturesNeedRepairModel>();

            foreach (var v in resultList)
            {
                xxx.AddRange(v);
                xxx.Add(new ArchitecturesNeedRepairModel
                {
                    ArchitectureId = 0,
                    ArchitectureTitle = "",
                    ArchitectureState = State.Normal,
                    RepairCost = 0,
                    RestorationKind = RestorationKind.Целостная,
                    Volume = 0
                });
            }

            RepairsList = xxx;
        }


        private async void LoadData()
        {
            _architectures = (await _architecturesManager.GetArchitectures()).ToList();
            _restorations = (await _restorationsManager.GetRestorations()).ToList();
            _restorationKindsList = Enum.GetValues(typeof(RestorationKind)).Cast<RestorationKind>().ToList();
        }


        private async Task<List<ArchitecturesNeedRepairModel>> LoadCombinations()
        {
            var tmpList = new List<ArchitecturesNeedRepairModel>();

            var repairs = await _repairsManager.GetRepairs();
            var needRestorationList = _architectures
                .Where(a => 
                    (a.State == State.Bad || a.State == State.Awful) 
                  && !repairs.Any(x => x.ArchitectureId == a.Id && (x.RestorationDate == null || x.RestorationDate.Value > DateTime.Now)))
                .Select(a => new ArchitecturesNeedRepairModel
                {
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

                    architecture.ArchitectureId = (tmpList.Count == 0) ? 1 : tmpList.Max(a => a.ArchitectureId) + 1;
                    architecture.RepairCost = restoration.Outlays * arch.Volume;
                    architecture.RestorationKind = rest;

                    tmpList.Add(architecture);
                }
            }

            RepairsList = tmpList;

            return RepairsList;
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
        public double RepairCost { get; set; }
        public RestorationKind RestorationKind { get; set; }
    }    
}
