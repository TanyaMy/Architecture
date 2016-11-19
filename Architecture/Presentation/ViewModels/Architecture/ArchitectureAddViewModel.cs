using System;
using System.Collections.Generic;
using System.Windows.Input;
using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureAddViewModel : ViewModelBase
    {
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IStylesManager _stylesManager;
        private readonly IArchitectManager _architectsManager;

        private List<Data.Entities.Style> _stylesList;
        private List<Data.Entities.Architect> _architectsList;

        private string _title;
        private DateTimeOffset _createdDate;
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

            SaveCommand = new RelayCommand(async () => await SaveToDb());

            InitData();
        }

        private async void InitData()
        {
            StatesList = Enum.GetValues(typeof(State)).Cast<State>().ToList();

            StylesList = (await _stylesManager.GetStyles()).ToList();

            ArchitectsList = (await _architectsManager.GetArchitects()).ToList();
        }

        public ICommand SaveCommand { get; }

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

        public DateTimeOffset CreatedDate
        {
            get { return _createdDate; }
            set { Set(() => CreatedDate, ref _createdDate, value); }
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

        private async Task SaveToDb()
        {
            var architecture = new Data.Entities.Architecture(
                Title, CreatedDate.Year, Country, City, Address,
                Square, Heigth, State, Architect.Id, Style.Id);

            await _architecturesManager.AddArchitecture(architecture);
        }
    }
}
