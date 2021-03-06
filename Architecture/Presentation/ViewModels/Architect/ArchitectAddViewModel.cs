﻿using System;
using System.Windows.Input;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using ArchitectModel = Architecture.Data.Entities.Architect;
using Architecture.Presentation.Helpers.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Architecture.Presentation.Models;
using System.Linq;

namespace Architecture.Presentation.ViewModels.Architect
{
    public class ArchitectAddViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IArchitectManager _architectsManager;

        private readonly ArchitectModel _architect;

        private string _name;
        private string _surname;
        private string _nationality;
        private int _birthYear;
        private int _deathYear;
        private bool _isDead;

        public ArchitectAddViewModel(
            IArchitectManager architectsManager)
        {
            _architectsManager = architectsManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectInternal");

            _architect = _customNavigationService.CurrentPageParams as ArchitectModel;

            SaveCommand = _architect == null
             ? new RelayCommand(async () => await AddArchitect())
             : new RelayCommand(async () => await UpdateArchitect());

            ActionText = _architect == null ? "Добавление" : "Редактирование";
            ButtonText = _architect == null ? "Добавить" : "Сохранить изменения";
           
            SetupFields();
        }
       

        public ICommand SaveCommand { get; }

        public string ActionText { get; }
        public string ButtonText { get; }

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

        public int BirthYear
        {
            get { return _birthYear; }
            set { Set(() => BirthYear, ref _birthYear, value); }
        }

        public int DeathYear
        {
            get { return _deathYear; }
            set { Set(() => DeathYear, ref _deathYear, value); }
        }

        public bool IsDead
        {
            get { return _isDead; }
            set { Set(() => IsDead, ref _isDead, value); }
        }


        private async Task AddArchitect()
        {
            var architect = new ArchitectModel(
                Name, Surname, Nationality, BirthYear,  DeathYear);

            await _architectsManager.AddArchitect(architect);

            _customNavigationService.NavigateTo(PageKeys.ArchitectMain);
        }

        private async Task UpdateArchitect()
        {
            _architect.Name = Name;
            _architect.Surname = Surname;
            _architect.Nationality = Nationality;
            _architect.BirthYear = BirthYear;
            _architect.DeathYear = DeathYear;

            await _architectsManager.UpdateArchitect(_architect);

            _customNavigationService.NavigateTo(PageKeys.ArchitectMain);
        }

        private void SetupFields()
        {
            ArchitectModel editableArch = _architect;          

            Name = editableArch?.Name ?? string.Empty;
            Surname = editableArch?.Surname ?? string.Empty;
            Nationality = editableArch?.Nationality ?? string.Empty;
            BirthYear = editableArch?.BirthYear ?? 0;
            DeathYear = editableArch?.DeathYear ?? 0;
        }
    }
}
