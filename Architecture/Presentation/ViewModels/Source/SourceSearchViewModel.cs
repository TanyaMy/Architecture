using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Source
{
    public class SourceSearchViewModel : ViewModelBase
    {
        private readonly ISourcesManager _sourcesManager;

        public SourceSearchViewModel(
           ISourcesManager sourcesManager)
        {
            _sourcesManager = sourcesManager;

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
