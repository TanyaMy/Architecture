using System.Linq;
using Arcitecture.Presentation.ViewModels.Common;
using RepairModel = Architecture.Data.Entities.Repair;
using Architecture.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Architecture.Presentation.ViewModels.Repair
{
    public class RepairMainViewModel : ViewModelBase
    {
        private readonly IRepairsManager _repairsManager;

        private IList<RepairModel> _repairs;

        public RepairMainViewModel(IRepairsManager repairsManager)
        {
            _repairsManager = repairsManager;

            InitData();
        }

        public IList<RepairModel> RepairList
        {
            get { return _repairs; }
            set { Set(() => RepairList, ref _repairs, value); }
        }

        public async Task DeleteRepair(object repair)
        {
            var rep = repair as RepairModel;

            if (rep == null)
                return;

            await _repairsManager.RemoveRepair(rep.ArchitectureId, rep.RestorationKind);
        }

        protected override void OnPageLoaded()
        {
            base.OnPageLoaded();

            InitData();
        }

        private async void InitData()
        {
            RepairList = (await _repairsManager.GetRepairs()).ToList();
        }
    }
}
