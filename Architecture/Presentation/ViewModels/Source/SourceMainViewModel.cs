using System.Linq;
using Arcitecture.Presentation.ViewModels.Common;
using SourceModel = Architecture.Data.Entities.Source;
using Architecture.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Presentation.ViewModels.Source
{
    public class SourceMainViewModel : ViewModelBase
    {
        private readonly ISourcesManager _sourcesManager;

        private IList<SourceModel> _sources;

        public SourceMainViewModel(ISourcesManager stylesManager)
        {
            _sourcesManager = stylesManager;

            InitData();
        }

        public IList<SourceModel> SourceList
        {
            get { return _sources; }
            set { Set(() => SourceList, ref _sources, value); }
        }

        public async Task DeleteSource(object source)
        {
            var sourc = source as SourceModel;

            if (sourc == null)
                return;

            await _sourcesManager.RemoveSource(sourc.Id);
        }

        protected override void OnPageLoaded()
        {
            base.OnPageLoaded();

            InitData();
        }

        private async void InitData()
        {
            SourceList = (await _sourcesManager.GetSources()).ToList();
        }
    }
}
