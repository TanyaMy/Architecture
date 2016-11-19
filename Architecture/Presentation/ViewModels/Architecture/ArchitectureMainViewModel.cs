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

        private readonly IList<ArchitectureModel> _architectures;

        public ArchitectureMainViewModel(IArchitecturesManager architecturesManager)
        {
            _architecturesManager = architecturesManager;

            InitData();
        }

        public IList<ArchitectureModel> ArchitectureList { get; set; }


        private async Task InitData()
        {
            ArchitectureList = (await _architecturesManager.GetArchitectures()).ToList();
        }
    }
}
