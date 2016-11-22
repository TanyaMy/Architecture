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

        private List<ArchitectureModel> _architectures;
        private List<RepairModel> _repairs;

        private string _statisticsType;

        public ArchitectureStatisticsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager)
        {
            _repairsManager = repairsManager;
            _architecturesManager = architecturesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectureInternal");

            LoadData();
        }

        public event StatisticsTypeChangedDelegate OnStatisticsTypeChanged;

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
                            OnStatisticsTypeChanged?.Invoke(ArchitectureCountryStateList);
                            break;
                        }
                    case "Стиль сооружений по странам":
                        {
                            OnStatisticsTypeChanged?.Invoke(ArchitectureCountryStyleList);
                            break;
                        }

                    case "Частота проведения разных видов реставрации":
                        {
                            OnStatisticsTypeChanged?.Invoke(RestorationKindList);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public List<object> ArchitectureCountryStateList = new List<object>();

        public List<object> ArchitectureCountryStyleList = new List<object>();

        public List<object> RestorationKindList = new List<object>();

        private async void LoadData()
        {           

            _architectures = (await _architecturesManager.GetArchitectures()).ToList();
            _repairs = (await _repairsManager.GetRepairs()).ToList();


            ArchitectureCountryStateList = _architectures.GroupBy(a => a.Country, a => a.State)
                                            .Select(ar => (object)new
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
