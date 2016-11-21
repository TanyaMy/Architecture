using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using RepairModel = Architecture.Data.Entities.Repair;
using ArchitectureModel = Architecture.Data.Entities.Architecture;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public delegate void ReportTypeChangedDelegate(object collection);

    public class ArchitectureReportsViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRepairsManager _repairsManager;
        private readonly IArchitecturesManager _architecturesManager;

        private List<RepairModel> _repairs;
        private List<ArchitectureModel> _architectures;

        private string _reportType;

        public ArchitectureReportsViewModel(IRepairsManager repairsManager, IArchitecturesManager architecturesManager)
        {
            _repairsManager = repairsManager;
            _architecturesManager = architecturesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");

            LoadData();
        }

        public event ReportTypeChangedDelegate OnReportTypeChanged;

        public IList<string> ReportTypes => new List<string>
        {
            "Реставрации и затраты за 10 лет",
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
                    case "Реставрации и затраты за 10 лет":
                    {
                        OnReportTypeChanged?.Invoke(RepairList);
                        break;
                    }
                    case "Наистарейшие сооружения":
                    {
                        OnReportTypeChanged?.Invoke(OldArchitectureList);
                        break;
                    }
                    case "Состояние сооружений":
                    {
                        OnReportTypeChanged?.Invoke(ArchitectureStateList);
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }

        public List<RepairModel> RepairList
        {
            get { return _repairs; }
            set { Set(() => RepairList, ref _repairs, value); }
        }

        public List<ArchitectureModel> OldArchitectureList
        {
            get { return _architectures; }
            set { Set(() => OldArchitectureList, ref _architectures, value); }
        }

        public List<ArchitectureModel> ArchitectureStateList
        {
            get { return _architectures; }
            set { Set(() => ArchitectureStateList, ref _architectures, value); }
        }

        private async void LoadData()
        {
            //вид реставрации, название сооружения, дата ремонта не ранее 2006, затраты ремонта
            //
            //название сооружения, дата создания ранее 1800 года в порядке возрастания
            //
            // название сооружения, его состояние
            //

            _architectures = (await _architecturesManager.GetArchitectures()).ToList();

            OldArchitectureList = _architectures.Where(a => a.CreationYear < 1800).ToList();

            ArchitectureStateList = new List<ArchitectureModel>(_architectures);

            RepairList = (await _repairsManager.GetRepairs())
                .Where(r => r.RestorationDate > DateTime.Now.AddYears(-10))
                .ToList();
        }
    }
}
