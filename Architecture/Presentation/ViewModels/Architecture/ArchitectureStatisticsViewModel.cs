using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using RepairModel = Architecture.Data.Entities.Repair;
using ArchitectureModel = Architecture.Data.Entities.Architecture;
using System.Collections.Generic;
using System.Linq;


namespace Architecture.Presentation.ViewModels.Architecture
{
    public delegate void StatisticsTypeChangedDelegate(object collection);

    public class ArchitectureStatisticsViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRepairsManager _repairsManager;
        private readonly IArchitecturesManager _architecturesManager;

        private List<object> _dataList;

        private List<ArchitectureModel> _architectures;
        private List<RepairModel> _repairs;

        private List<object> _architectureCountryStateList;
        private List<object> _architectureCountryStyleList;
        private List<object> _restorationKindList;

        private string _statisticsType;

        public ArchitectureStatisticsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager)
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

        public IList<string> StatisticsTypes => new List<string>
        {
            "Состояние сооружений по странам",
            "Стиль сооружений по странам",
            "Частота проведения разных видов реставрации"
        };

    
        public string StatisticsType
        {
            get { return _statisticsType; }
            set
            {
                Set(() => StatisticsType, ref _statisticsType, value);

                switch (value)
                {
                    case "Состояние сооружений по странам":
                        {
                            DataList = _architectureCountryStateList;
                            break;
                        }
                    case "Стиль сооружений по странам":
                        {
                            DataList = _architectureCountryStateList;
                            break;
                        }

                    case "Частота проведения разных видов реставрации":
                        {
                            DataList = _restorationKindList;
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


            _architectureCountryStateList = _architectures.GroupBy(a => a.Country, a => a.State)
                                            .Select(ar => (object) new
                                            {                                               
                                                Quantity = ar.Count().ToString()
                                            }).ToList();

            //var m_dbConnection = new SqliteConnection("Data Source=Architecture.db;");
            //m_dbConnection.Open();
            //string sql = "select Architectures.Country, Architectures.State, Count(Architectures.Id) from Architectures GroupBy Country, State";
            //SqliteCommand command = new SqliteCommand(sql, m_dbConnection);
            //SqliteDataReader reader = command.ExecuteReader();
            //while( reader.Read())
            //{
            //    System.Diagnostics.Debug.WriteLine("Country: " + reader["Country"] + "\tState: " + reader["State"] + reader["Count(Id)"]);
            //}



            //ArchitectureCountryStyleList = 





            //RestorationKindList =

        }
    }
}
