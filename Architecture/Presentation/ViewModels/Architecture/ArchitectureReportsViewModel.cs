using System;
using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Architecture.Data.Entities;
using RepairModel = Architecture.Data.Entities.Repair;
using ArchitectureModel = Architecture.Data.Entities.Architecture;

namespace Architecture.Presentation.ViewModels.Architecture
{
   
    public delegate void ReportTypeChangedDelegate(object collection);

    public class ArchitectureReportsViewModel : ViewModelBase
    {
        private const string RepairAndExpensesType = "Ремонты и затраты за";
        private const string ArhitectureStatesType = "Состояние сооружений";

        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRepairsManager _repairsManager;
        private readonly IArchitecturesManager _architecturesManager;

        private List<object> _dataList;
        private string _dataString;
        private List<ArchitectureModel> _architectures;
        private List<RepairModel> _repairs;

        private List<object> _architectureStateList;
        private List<object> _repairList;
        private string _repairString;
        private string _archStateString;

        private string _reportType;
        private double _reportFor;
        private Visibility _isRepairAndExpensesReportVisibility;



        public ArchitectureReportsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager)
        {
            _repairsManager = repairsManager;
            _architecturesManager = architecturesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectureInternal");

            DataList = new List<object>();

            LoadData();

            ReportFor = 10;
            ReportType = RepairAndExpensesType;
        }

        public Visibility IsRepairAndExpensesReportVisibility
        {
            get { return _isRepairAndExpensesReportVisibility; }
            set { Set(() => IsRepairAndExpensesReportVisibility, ref _isRepairAndExpensesReportVisibility, value); }
        }

        public List<object> DataList
        {
            get { return _dataList; }
            set { Set(() => DataList, ref _dataList, value); }
        }

        public string DataString
        {
            get { return _dataString; }
            set { Set(() => DataString, ref _dataString, value); }
        }

        public IList<string> ReportTypes => new List<string>
        {
            RepairAndExpensesType,
            ArhitectureStatesType
        };      

        public string ReportType
        {
            get { return _reportType; }
            set
            {
                Set(() => ReportType, ref _reportType, value);

                switch (value)
                {
                    case RepairAndExpensesType:
                    {
                            DataList = _repairList;
                            DataString = _repairString;
                            IsRepairAndExpensesReportVisibility = Visibility.Visible;
                            break;
                    }     
                    case ArhitectureStatesType:
                    {
                            DataList = _architectureStateList;
                            DataString = _archStateString;
                            IsRepairAndExpensesReportVisibility = Visibility.Collapsed;
                            break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }

        public double ReportFor
        {
            get { return _reportFor; }
            set
            {
                _reportFor = value;
                UpdateReportAboutRepairsAndExpensesFor(Convert.ToInt32(value));
                ReportType = RepairAndExpensesType;
            }
        }

        private async void LoadData()
        {
            _architectures = (await _architecturesManager.GetArchitectures()).ToList();
            _repairs = (await _repairsManager.GetRepairs()).ToList();

            _architectureStateList = _architectures.Select(ar => (object)new
                                    {
                                        Название = ar.Title,
                                        Состояние = ar.State.ToString()
                                    }).ToList();

            var awful = _architectures.Count(a => a.State == State.Awful);
            var bad = _architectures.Count(a => a.State == State.Bad);
            var normal = _architectures.Count(a => a.State == State.Normal);
            var good = _architectures.Count(a => a.State == State.Good);
            var great = _architectures.Count(a => a.State == State.Great);

            _archStateString = "Всего сооружений: " + _architectureStateList.Count +
                                ", в ужасном состоянии " + awful + 
                                ", в плохом - " + bad +
                                ", в нормальном - " + normal +
                                ", в хорошем - " + good +
                                ", в отличном - " + great;
        }

        private void UpdateReportAboutRepairsAndExpensesFor(int years)
        {
            var filteredRepairs = _repairs
                .Where(x => x.RestorationDate.Year >= DateTime.Now.Year - years)
                .ToArray();

            _repairList = filteredRepairs.Select(rep => (object) new
                {
                    Название = rep.Architecture.Title,
                    Вид_реставрации = rep.RestorationKind.ToString(),
                    Стоимость_ремонта = rep.RestorationCost,
                    Дата_ремонта = rep.RestorationDate
                }).ToList();

            var sum = filteredRepairs.Sum(x => x.RestorationCost);

            _repairString = $"Всего проведено ремонтов за {years} лет: {_repairList.Count}. Потрачено: {sum};";
        }
    }
}
