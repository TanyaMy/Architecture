using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Architect
{
    public class ArchitectSearchViewModel : ViewModelBase
    {
        private readonly IArchitectManager _architectsManager;

        public ArchitectSearchViewModel(
           IArchitectManager architectsManager)
        {
            _architectsManager = architectsManager;

            //FindCommand = ;

        }

        public ICommand FindCommand { get; }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { Set(() => Surname, ref _surname, value); }
        }
    }
}
