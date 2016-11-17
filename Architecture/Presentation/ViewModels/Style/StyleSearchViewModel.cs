using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleSearchViewModel : ViewModelBase
    {
        private readonly IStylesManager _stylesManager;

        public StyleSearchViewModel(
           IStylesManager stylesManager)
        {
            _stylesManager = stylesManager;

            //FindCommand = ;
        }

        public ICommand FindCommand { get; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }
    }
}
