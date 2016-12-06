using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using RepairModel = Architecture.Data.Entities.Repair;
using ArchitectureModel = Architecture.Data.Entities.Architecture;
using StyleModel = Architecture.Data.Entities.Style;
using System.Collections.Generic;
using System.Linq;
using Architecture.Data.Entities;

namespace Architecture.Presentation.ViewModels.Architecture
{
     public class ArchitectureStatisticsViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRepairsManager _repairsManager;
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IStylesManager _stylesManager;

        private List<object> _dataList;

        private List<ArchitectureModel> _architectures;
        private List<StyleModel> _styles;
        private List<RepairModel> _repairs;

        private List<object> _architectureCountryStateList;
        private List<object> _architectureCountryStyleList;
        private List<object> _restorationKindList;

        private string _statisticsType;

        public ArchitectureStatisticsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager,
            IStylesManager stylesManager)
        {
            _repairsManager = repairsManager;
            _architecturesManager = architecturesManager;
            _stylesManager = stylesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectureInternal");

            _architectureCountryStateList = new List<object>();
            _architectureCountryStyleList = new List<object>();
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
                            DataList = _architectureCountryStyleList;
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
            _styles = (await _stylesManager.GetStyles()).ToList();


            var groupedByCountryList = _architectures.OrderBy(e => e.Country).GroupBy(ar => ar.Country);
            foreach (var element in groupedByCountryList)
            {
                var groupedByStateList = element.GroupBy(e => e.State)
                    .Select(f1 => (object)new
                    {
                        Страна = element.Key,
                        Состояние = f1.Key.ToString(),
                        Количество_сооружений = f1.Count()
                    });
                foreach (var arch in groupedByStateList)
                    _architectureCountryStateList.Add(arch);
            }


        
            foreach (var element in groupedByCountryList)
            {
                var groupedByStyleList = element.GroupBy(e => e.Style.Title, e => e.StyleId)
                    .Select(f1 => (object)new
                    {
                        Страна = element.Key,
                        Стиль = f1.Key,
                        Количество_сооружений = f1.Count()
                    });
                foreach (var arch in groupedByStyleList)
                    _architectureCountryStyleList.Add(arch);
            }


            _restorationKindList = _repairs.GroupBy(r => r.RestorationKind)
                .Select(f => (object)new
                {
                    Вид_реставрации = f.Key.ToString(),
                    Количество_сооружений = f.Count()
                }).ToList();
        }
    }
}
