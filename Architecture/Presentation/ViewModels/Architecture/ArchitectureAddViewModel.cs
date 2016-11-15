using System;
using System.Windows.Input;
using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureAddViewModel : ViewModelBase
    {
        private readonly IArchitecturesManager _architecturesManager;

        private string _name;
        private DateTime _createdDate;
        private string _country;
        private string _city;
        private string _address;
        private string _square;
        private int _heigth;
        private string _style;
        private Data.Entities.Architect _architect;

        public ArchitectureAddViewModel(IArchitecturesManager architecturesManager)
        {
            _architecturesManager = architecturesManager;

            SaveCommand = new RelayCommand(Save);
        }

        public ICommand SaveCommand { get; }

        private void Save()
        {
            
        }
    }
}
