using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Architect
{
    public class ArchitectFilterViewModel : ViewModelBase
    {
        private readonly IArchitectManager _architectsManager;

        private string _name;
        private string _surname;
        private string _nationality;

        public ArchitectFilterViewModel(
           IArchitectManager architectsManager)
        {
            _architectsManager = architectsManager;

            //FilterCommand = ;

        }

        public ICommand FilterCommand { get; }


        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        public string Surname
        {
            get { return _surname; }
            set { Set(() => Surname, ref _surname, value); }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { Set(() => Nationality, ref _nationality, value); }
        }
    }
}
