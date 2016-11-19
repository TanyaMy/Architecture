using System;
using System.Windows.Input;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;

namespace Architecture.Presentation.ViewModels.Architect
{
    public class ArchitectAddViewModel : ViewModelBase
    {       
        private readonly IArchitectManager _architectsManager;

        private string _name;
        private string _surname;
        private string _nationality;
        private DateTime _birthDate;
        private DateTime _deathDate;

        public ArchitectAddViewModel(
            IArchitectManager architectsManager)
        {
            _architectsManager = architectsManager;

            SaveCommand = new RelayCommand(async () => await SaveToDb());
            
        }       

        public ICommand SaveCommand { get; }       

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

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { Set(() => BirthDate, ref _birthDate, value); }
        }

        public DateTime DeathDate
        {
            get { return _deathDate; }
            set { Set(() => DeathDate, ref _deathDate, value); }
        }
               

        private async Task SaveToDb()
        {
            var architect = new Data.Entities.Architect(
                Name, Surname, Nationality, BirthDate, 
                DeathDate);

            await _architectsManager.AddArchitect(architect);
        }
    }
}
