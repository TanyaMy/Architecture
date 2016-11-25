using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SourceModel = Architecture.Data.Entities.Source;
using ArchitectureSourceModel = Architecture.Data.Entities.ArchitectureSource;

using ArchitectureModel = Architecture.Data.Entities.Architecture;

namespace Architecture.Presentation.ViewModels.Source
{
    public class SourceAddArchitectureViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly ISourcesManager _sourcesManager;
        private readonly IArchitecturesManager _architecturesManager;

        private readonly SourceModel _source;
        private List<Data.Entities.Architecture> _architecturesList;
      
        private Data.Entities.Architecture _architecture;
        private ArchitectureModel _selectedTableItem;


        public SourceAddArchitectureViewModel(ISourcesManager sourcesManager, IArchitecturesManager architecturesManager)
        {
            _sourcesManager = sourcesManager;
            _architecturesManager = architecturesManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("SourceInternal");

            _source = _customNavigationService.CurrentPageParams as SourceModel;

            SaveCommand = new RelayCommand(async () => await AddSourceArchitecture());

            ActionText =  "Добавление сооружения";
            ButtonText = "Добавить";

            InitData();
        }

        private async void InitData()
        {
            ArchitecturesList = (await _architecturesManager.GetArchitectures()).ToList();
        }

        public ICommand SaveCommand { get; }

        public string ActionText { get; }
        public string ButtonText { get; }
     

        public List<Data.Entities.Architecture> ArchitecturesList
        {
            get { return _architecturesList; }
            set { Set(() => ArchitecturesList, ref _architecturesList, value); }
        }

        public ArchitectureModel SelectedTableItem
        {
            get { return _selectedTableItem; }
            set { Set(() => SelectedTableItem, ref _selectedTableItem, value); }
        }

        public List<ArchitectureModel> Architectures
        {
            get { return _architecturesManager.GetArchitecturesListBySourceId(_source.Id); }
        }

        public Data.Entities.Architecture Architecture
        {
            get { return _architecture; }
            set { Set(() => Architecture, ref _architecture, value); }
        }

        public string Title
        {
            get { return _source.Title; }
        }

        private async Task AddSourceArchitecture()
        {
            var source = await _sourcesManager.GetSourceById(_source.Id);

            if (source.ArchitecturesSources == null)
                source.ArchitecturesSources = new List<ArchitectureSourceModel>();

            source.ArchitecturesSources.Add(
            new ArchitectureSourceModel
            {
                ArchitectureId = Architecture.Id,
                SourceId = source.Id
            });

            await _sourcesManager.UpdateSource(source);
        }

        public async Task DeleteSourceArchitecture(object arch)
        {
            var architecture = arch as ArchitectureModel;
            var source = await _sourcesManager.GetSourceById(_source.Id);

            if (architecture == null)
                return;

            var ArchSour = new ArchitectureSourceModel
            {
                ArchitectureId = architecture.Id,
                SourceId = source.Id
            };

            _source.ArchitecturesSources.Remove(ArchSour);
          
            await _sourcesManager.UpdateSource(_source);

            Architectures.Remove(architecture);
        }
    }
}
