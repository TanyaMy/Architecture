using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchitectModel = Architecture.Data.Entities.Architect;

namespace Architecture.Presentation.ViewModels.Architect
{
    public class ArchitectMainViewModel : ViewModelBase
    {
        private readonly IArchitectManager _architectsManager;

        private IList<ArchitectModel> _architects;

        public ArchitectMainViewModel(IArchitectManager architectsManager)
        {
            _architectsManager = architectsManager;

            InitData();
        }

        public IList<ArchitectModel> ArchitectList
        {
            get { return _architects; }
            set { Set(() => ArchitectList, ref _architects, value); }
        }

        public async Task DeleteArchitect(object architect)
        {
            var arch = architect as ArchitectModel;

            if (arch == null)
                return;

            await _architectsManager.RemoveArchitect(arch.Id);
        }

        protected override void OnPageLoaded()
        {
            base.OnPageLoaded();

            InitData();
        }

        private async void InitData()
        {
            ArchitectList = (await _architectsManager.GetArchitects()).ToList();
        }
    }
}
