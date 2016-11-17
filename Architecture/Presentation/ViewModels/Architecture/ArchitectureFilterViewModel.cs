using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureFilterViewModel : ViewModelBase
    {
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IStylesManager _stylesManager;
        private readonly IArchitectManager _architectsManager;

        private List<Data.Entities.Style> _stylesList;
        private List<Data.Entities.Architect> _architectsList;

        private string _title;
        private string _country;
        private string _city;
        private State _state;
        private Data.Entities.Style _style;
        private Data.Entities.Architect _architect;

        public ArchitectureFilterViewModel(
            IArchitecturesManager architecturesManager,
            IStylesManager stylesManager,
            IArchitectManager architectsManager)
        {
            _architecturesManager = architecturesManager;
            _stylesManager = stylesManager;
            _architectsManager = architectsManager;

           // FilterCommand = 

            InitData();
        }

        private async void InitData()
        {
            StatesList = Enum.GetValues(typeof(State)).Cast<State>().ToList();

            StylesList = (await _stylesManager.GetStyles()).ToList();

            ArchitectsList = (await _architectsManager.GetArchitects()).ToList();
        }

        public ICommand FilterCommand { get; }

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

    }
}
