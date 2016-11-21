using System.Linq;
using Arcitecture.Presentation.ViewModels.Common;
using RestorationModel = Architecture.Data.Entities.Restoration;
using Architecture.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Presentation.ViewModels.Restoration
{
    public class RestorationMainViewModel : ViewModelBase
    {
        private readonly IRestorationsManager _restorationsManager;

        private IList<RestorationModel> _restorations;

        public RestorationMainViewModel(IRestorationsManager restorationsManager)
        {
            _restorationsManager = restorationsManager;

            InitData();
        }

        public IList<RestorationModel> RestorationList
        {
            get { return _restorations; }
            set { Set(() => RestorationList, ref _restorations, value); }
        }

        public async Task DeleteRestoration(object restoration)
        {
            var restorat = restoration as RestorationModel;

            if (restorat == null)
                return;

            await _restorationsManager.RemoveRestoration(restorat.RestorationKind);
        }

        protected override void OnPageLoaded()
        {
            base.OnPageLoaded();

            InitData();
        }

        private async void InitData()
        {
            RestorationList = (await _restorationsManager.GetRestorations()).ToList();
        }
    }
}
