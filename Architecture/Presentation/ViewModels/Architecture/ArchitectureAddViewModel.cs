using System;
using System.Collections.Generic;
using System.Windows.Input;
using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Microsoft.Practices.ServiceLocation;
using ArchitectureModel = Architecture.Data.Entities.Architecture;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureAddViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IStylesManager _stylesManager;
        private readonly IArchitectManager _architectsManager;

        private List<Data.Entities.Style> _immutableStylesList;
        private List<Data.Entities.Style> _stylesList;
        private List<Data.Entities.Architect> _immutableArchitectsList;
        private List<Data.Entities.Architect> _architectsList;

        private readonly ArchitectureModel _architecture;

        private string _title;
        private int _createdYear;
        private string _country;
        private string _city;
        private string _address;
        private double _square;
        private double _heigth;
        private State _state;
        private Data.Entities.Style _style;
        private Data.Entities.Architect _architect;

        public ArchitectureAddViewModel(
            IArchitecturesManager architecturesManager,
            IStylesManager stylesManager,
            IArchitectManager architectsManager)
        {
            _architecturesManager = architecturesManager;
            _stylesManager = stylesManager;
            _architectsManager = architectsManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectureInternal");

            _architecture = _customNavigationService.CurrentPageParams as ArchitectureModel;

            SaveCommand = _architecture == null 
                ? new RelayCommand(async () => await AddArchitecture())
                : new RelayCommand(async () => await UpdateArchitecture());

            ActionText = _architecture == null ? "Добавление" : "Редактирование";
            ButtonText = _architecture == null ? "Добавить" : "Сохранить изменения";

            InitData();
            SetupFields();
        }

        private async void InitData()
        {
            StatesList = Enum.GetValues(typeof(State)).Cast<State>().ToList();

            _immutableStylesList = (await _stylesManager.GetStyles()).ToList();
            StylesList = _immutableStylesList.ToList();

            _immutableArchitectsList = (await _architectsManager.GetArchitects()).ToList();
            ArchitectsList = (await _architectsManager.GetArchitects()).ToList();
        }

        public ICommand SaveCommand { get; }

        public string ActionText { get; }
        public string ButtonText { get; }

        public List<State> StatesList { get; private set; }

        public List<Data.Entities.Style> StylesList
        {
            get { return _stylesList; }
            set { Set(() => StylesList, ref _stylesList, value); }
        }

        public List<Data.Entities.Architect> ArchitectsList
        {
            get { return _architectsList; }
            set { Set(() => ArchitectsList, ref _architectsList, value); }
        }

        public string Title
        {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }

        public int CreatedYear
        {
            get { return _createdYear; }
            set { Set(() => CreatedYear, ref _createdYear, value); }
        }

        public string Country
        {
            get { return _country; }
            set { Set(() => Country, ref _country, value); }
        }

        public string City
        {
            get { return _city; }
            set { Set(() => City, ref _city, value); }
        }

        public string Address
        {
            get { return _address; }
            set { Set(() => Address, ref _address, value); }
        }

        public double Square
        {
            get { return _square; }
            set { Set(() => Square, ref _square, value); }
        }

        public double Heigth
        {
            get { return _heigth; }
            set { Set(() => Heigth, ref _heigth, value); }
        }

        public State State
        {
            get { return _state; }
            set { Set(() => State, ref _state, value); }
        }

        public Data.Entities.Style Style
        {
            get { return _style; }
            set { Set(() => Style, ref _style, value); }
        }

        public Data.Entities.Architect Architect
        {
            get { return _architect; }
            set { Set(() => Architect, ref _architect, value); }
        }

        public void FilterStylesForAutosuggest(string filterText)
        {
            filterText = filterText.Trim().ToLower();

            if (string.IsNullOrEmpty(filterText))
            {
                StylesList = _immutableStylesList.ToList();
                return;
            }

            StylesList = _immutableStylesList.Where(x => x.Title.ToLower().Contains(filterText)).ToList();
        }

        public void FilterArchitectsForAutosuggest(string filterText)
        {
            filterText = filterText.Trim().ToLower();

            if (string.IsNullOrEmpty(filterText))
            {
                ArchitectsList = _immutableArchitectsList.ToList();
                return;
            }

            ArchitectsList = _immutableArchitectsList.Where(x => x.Surname.ToLower().Contains(filterText)).ToList();
        }

        private async Task AddArchitecture()
        {
            var architecture = new ArchitectureModel(
                Title, CreatedYear, Country, City, Address,
                Square, Heigth, State, Architect.Id, Style.Id);

            await _architecturesManager.AddArchitecture(architecture);

            _customNavigationService.NavigateTo(PageKeys.ArchitectureMain);
        }

        private async Task UpdateArchitecture()
        {
            _architecture.Title = Title;
            _architecture.CreationYear = CreatedYear;
            _architecture.Country = Country;
            _architecture.City = City;
            _architecture.Address = Address;
            _architecture.Square = Square;
            _architecture.Height = Heigth;
            _architecture.State = State;
            _architecture.ArchitectId = Architect.Id;
            _architecture.StyleId = Style.Id;

            await _architecturesManager.UpdateArchitecture(_architecture);

            _customNavigationService.NavigateTo(PageKeys.ArchitectureMain);
        }

        private void SetupFields()
        {
            ArchitectureModel editableArch = _architecture;

            Title = editableArch?.Title ?? string.Empty;
            CreatedYear = editableArch?.CreationYear ?? Convert.ToInt32(DateTime.Now.Year);
            Country = editableArch?.Country ?? string.Empty;
            City = editableArch?.City ?? string.Empty;
            Address = editableArch?.Address ?? string.Empty;
            Square = editableArch?.Square ?? 0;
            Heigth = editableArch?.Height ?? 0;
            State = editableArch?.State ?? State.Great;
            Architect = editableArch?.Architect;
            Style = editableArch?.Style;
        }
    }
}
