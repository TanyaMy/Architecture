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
            _customNavigationService.NavigateTo(PageKeys.SourceMain);
        }
               
    }
}
