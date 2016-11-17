using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureSearchViewModel : ViewModelBase
    {

        private readonly IArchitecturesManager _architecturesManager;      

        private string _title;

        public ArchitectureSearchViewModel(
            IArchitecturesManager architecturesManager)
        {
            _architecturesManager = architecturesManager;

            //FindCommand = 
        }
              

        public ICommand FindCommand { get; }
        

        public string Title
        {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }

        
    }
}
