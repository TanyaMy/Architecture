using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using RepairModel = Architecture.Data.Entities.Repair;
using ArchitectureModel = Architecture.Data.Entities.Architecture;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Data.Sqlite;
using System.Collections;
using Architecture.Data.Entities;

namespace Architecture.Presentation.ViewModels.Architecture
{
   
    public delegate void ReportTypeChangedDelegate(object collection);

    public class ArchitectureReportsViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRepairsManager _repairsManager;
        private readonly IArchitecturesManager _architecturesManager;

        private List<object> _dataList;
        private string _dataString;
        private List<ArchitectureModel> _architectures;
        private List<RepairModel> _repairs;

        private List<object> _architectureStateList;
        private List<object> _oldArchitectureList;
        private List<object> _repairList;
        private string _repairString;      
        private string _oldArchString;
        private string _archStateString;

        private string _reportType;
        

        public ArchitectureReportsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager)
        {
            _repairsManager = repairsManager;
            _architecturesManager = architecturesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectureInternal");

            DataList = new List<object>();

            LoadData();
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
            "Ремонты и затраты за 10 лет",
            "Наистарейшие сооружения",
            "Состояние сооружений"
        };      

        public string ReportType
        {
            get { return _reportType; }
            set
            {
                Set(() => ReportType, ref _reportType, value);

                switch (value)
                {
                    case "Ремонты и затраты за 10 лет":
                    {
                            DataList = _repairList;
                            DataString = _repairString;
                            break;
                    }
                    case "Наистарейшие сооружения":
                    {
                            DataList = _oldArchitectureList;
                            DataString = _oldArchString;
                            break;
                    }
                        
                    case "Состояние сооружений":
                    {
                            DataList = _architectureStateList;
                            DataString = _archStateString;
                            break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }     

        private async void LoadData()
        {
            _architectures = (await _architecturesManager.GetArchitectures()).ToList();
            _repairs = (await _repairsManager.GetRepairs()).ToList();


            _oldArchitectureList = _architectures.Where(a => a.CreationYear < 1800)
                                                 .OrderByDescending(a => a.CreationYear)
                                                 .Select(ar => (object)new
                                                 {
                                                     Название = ar.Title,
                                                     Год_создания = ar.CreationYear
                                                 }).ToList();
            
            _oldArchString = "Всего сооружений старше 1800 года: " + _oldArchitectureList.Count();




            _architectureStateList = _architectures.Select(ar => (object)new
                                    {
                                        Название = ar.Title,
                                        Состояние = ar.State.ToString()
                                    }).ToList();

            var awful = _architectures.Where(a => a.State == State.Awful).Count();
            var bad = _architectures.Where(a => a.State == State.Bad).Count();
            var normal = _architectures.Where(a => a.State == State.Normal).Count();
            var good = _architectures.Where(a => a.State == State.Good).Count();
            var great = _architectures.Where(a => a.State == State.Great).Count();

            _archStateString = "Всего сооружений: " + _architectureStateList.Count() +
                                ", в ужасном состоянии " + awful + 
                                ", в плохом - " + bad +
                                ", в нормальном - " + normal +
                                ", в хорошем - " + good +
                                ", в отличном - " + great;



            _repairList = _repairs.Select(rep => (object)new
            {
                Название = rep.Architecture.Title,
                Вид_реставрации = rep.RestorationKind.ToString(),
                Стоимость_ремонта = rep.RestorationCost,
                Дата_ремонта = rep.RestorationDate
             }).ToList();        

            var sum = (await _repairsManager.GetRepairs())
                .Select(a => a.RestorationCost).Sum();

            _repairString = "Всего проведено ремонтов за 10 лет: " + _repairList.Count() +
               ". Потрачено: " + sum;
        }
    }
}
