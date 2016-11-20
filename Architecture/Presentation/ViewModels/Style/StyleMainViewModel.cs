using System.Linq;
using Arcitecture.Presentation.ViewModels.Common;
using StyleModel = Architecture.Data.Entities.Style;
using Architecture.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleMainViewModel : ViewModelBase
    {
        private readonly IStylesManager _stylesManager;

        private IList<StyleModel> _styles;

        public StyleMainViewModel(IStylesManager stylesManager)
        {
            _stylesManager = stylesManager;

            InitData();
        }

        public IList<StyleModel> StyleList
        {
            get { return _styles; }
            set { Set(() => StyleList, ref _styles, value); }
        }

        public async Task DeleteStyle(object style)
        {
            var styl = style as StyleModel;

            if (styl == null)
                return;

            await _stylesManager.RemoveStyle(styl.Id);
        }

        protected override void OnPageLoaded()
        {
            base.OnPageLoaded();

            InitData();
        }

        private async void InitData()
        {
            StyleList = (await _stylesManager.GetStyles()).ToList();
        }
    }
}
