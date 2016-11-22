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
      
        private List<ArchitectureModel> _architectures;
        private List<RepairModel> _repairs;

        private string _reportType;
        private string _stringType;

        public ArchitectureReportsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager)
        {
            _repairsManager = repairsManager;
            _architecturesManager = architecturesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectureInternal");
  
            LoadData();
        }

        public event ReportTypeChangedDelegate OnReportTypeChanged;

        public IList<string> ReportTypes => new List<string>
        {
            "Ремонты и затраты за 10 лет",
            "Наистарейшие сооружения",
            "Состояние сооружений"
        };

        public string StringType
        {
            get { return _stringType; }
            set
            {
                Set(() => StringType, ref _stringType, value);

                switch (value)
                {
                    case "Ремонты и затраты за 10 лет":
                        {
                            OnReportTypeChanged?.Invoke(OldArchString);
                            break;
                        }
                    case "Наистарейшие сооружения":
                        {
                            OnReportTypeChanged?.Invoke(RepairString);
                            break;
                        }
                    case "Состояние сооружений":
                        {
                            OnReportTypeChanged?.Invoke(ArchStateString);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

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
                        OnReportTypeChanged?.Invoke(RepairList);
                            StringType = RepairString;
                        break;
                    }
                    case "Наистарейшие сооружения":
                    {
                        OnReportTypeChanged?.Invoke(OldArchitectureList);
                            StringType = OldArchString;
                        break;
                    }
                        
                    case "Состояние сооружений":
                    {
                        OnReportTypeChanged?.Invoke(ArchitectureStateList);
                            StringType = ArchStateString;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }

        public List<object> RepairList = new List<object>();
        public string RepairString = "";

        public List<object> OldArchitectureList = new List<object>();
        public string OldArchString = "";

        public List<object> ArchitectureStateList = new List<object>();
        public string ArchStateString = "";

        private async void LoadData()
        {
            //вид реставрации, название сооружения, дата ремонта не ранее 2006, затраты ремонта
            //
            //название сооружения, дата создания ранее 1800 года в порядке возрастания
            //
            // название сооружения, его состояние
            //
            //var m_dbConnection = new SqliteConnection("Data Source=Architecture.db;");
            //m_dbConnection.Open();
            //string sql = "select * from Architectures";
            //SqliteCommand command = new SqliteCommand(sql, m_dbConnection);
            //SqliteDataReader reader = command.ExecuteReader();
            //for (int i = 0; i < _architectures.Count && reader.Read(); i++)
            //{
            //   // System.Diagnostics.Debug.WriteLine("Title: " + reader["Title"] + "\tCountry: " + reader["Country"]);
            //    _architectures[i].Title = reader["Title"].ToString();
            //    _architectures[i].CreationYear = Convert.ToInt32(reader["CreationYear"]);

            //}

            _architectures = (await _architecturesManager.GetArchitectures()).ToList();
            _repairs = (await _repairsManager.GetRepairs()).ToList();


            OldArchitectureList = (from arch in _architectures
                                  where arch.CreationYear < 1800
                                  orderby arch.CreationYear descending
                                  select (object)new { arch.Title, arch.CreationYear }).ToList();
            OldArchString = "Всего сооружений старше 1800 года: " + OldArchitectureList.Count();




            ArchitectureStateList = (from arch in _architectures
                                 select (object)new { arch.Title, arch.State}).ToList();//не отображает State

            var awful = _architectures.Where(a => a.State == State.Awful).Count();
            var bad = _architectures.Where(a => a.State == State.Bad).Count();
            var normal = _architectures.Where(a => a.State == State.Normal).Count();
            var good = _architectures.Where(a => a.State == State.Good).Count();
            var great = _architectures.Where(a => a.State == State.Great).Count();

            ArchStateString = "Всего сооружений: " + ArchitectureStateList.Count() + ", в ужасном состоянии " + awful + 
                ", в плохом - " + bad +
                ", в нормальном - " + normal +
                ", в хорошем - " + good +
                ", в отличном - " + great;



            RepairList = (from rep in _repairs
                          select (object)new { rep.Architecture.Title, rep.RestorationKind,//не отображает RestorationKind
                              rep.RestorationDate.Date, rep.RestorationCost}).ToList();

            var sum = (await _repairsManager.GetRepairs())
                .Select(a => a.RestorationCost).Sum();

            RepairString = "Всего проведено ремонтов за 10 лет: " + RepairList.Count() +
               ". Потрачено: " + sum;
        }
    }
}
