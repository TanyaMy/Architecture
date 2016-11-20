using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using ArchitectureModel = Architecture.Data.Entities.Architecture;


namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureMainViewModel : ViewModelBase
    {
        private readonly IArchitecturesManager _architecturesManager;

        private IList<ArchitectureModel> _architectures;

        public ArchitectureMainViewModel(IArchitecturesManager architecturesManager)
        {
            _architecturesManager = architecturesManager;

            InitData();
        }

        public IList<ArchitectureModel> ArchitectureList
        {
            get { return _architectures; }
            set { Set(() => ArchitectureList, ref _architectures, value); }
        }

        public async Task DeleteArchitecture(object architecture)
        {
            var arch = architecture as ArchitectureModel;

            if (arch == null)
                return;

            await _architecturesManager.RemoveArchitecture(arch.Id);
        }

        protected override void OnPageLoaded()
        {
            base.OnPageLoaded();

            InitData();
        }

        private async void InitData()
        {
            ArchitectureList = (await _architecturesManager.GetArchitectures()).ToList();
        }
    }
}
