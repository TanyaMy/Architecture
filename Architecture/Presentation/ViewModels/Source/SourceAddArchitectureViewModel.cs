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
using System.Collections.ObjectModel;

namespace Architecture.Presentation.ViewModels.Source
{
    public class SourceAddArchitectureViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly ISourcesManager _sourcesManager;
        private readonly IArchitecturesManager _architecturesManager;
        private readonly IArchitectureSourceManager _architectureSourceManager;

        private readonly SourceModel _source;
        private ObservableCollection<ArchitectureModel> _architecturesList;//для выпадающего списка
        private ObservableCollection<ArchitectureModel> _architectures;//для таблички

        private ArchitectureModel _architecture;
        private ArchitectureModel _selectedTableItem;


        public SourceAddArchitectureViewModel(ISourcesManager sourcesManager, IArchitecturesManager architecturesManager,
            IArchitectureSourceManager architectureSourceManager)
        {
            _sourcesManager = sourcesManager;
            _architecturesManager = architecturesManager;
            _architectureSourceManager = architectureSourceManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("SourceInternal");

            _source = _customNavigationService.CurrentPageParams as SourceModel;

            _architectures = new ObservableCollection<ArchitectureModel>(
                _architecturesManager.GetArchitecturesListBySourceId(_source.Id));

            SaveCommand = new RelayCommand(async () => await AddSourceArchitecture());

            ActionText =  "Добавление сооружения";
            ButtonText = "Добавить";

            InitData();
        }

        private async void InitData()
        {
            var x = (await _architecturesManager.GetArchitectures()).ToList();
            x.RemoveAll(a => Architectures.Contains(a));

            ArchitecturesList = new ObservableCollection<ArchitectureModel>(x);         
        }

        public ICommand SaveCommand { get; }

        public string ActionText { get; }
        public string ButtonText { get; }
     

        public ObservableCollection<ArchitectureModel> ArchitecturesList
        {
            get { return _architecturesList; }
            set { Set(() => ArchitecturesList, ref _architecturesList, value); }
        }

        public ArchitectureModel SelectedTableItem
        {
            get { return _selectedTableItem; }
            set { Set(() => SelectedTableItem, ref _selectedTableItem, value); }
        }

        public ObservableCollection<ArchitectureModel> Architectures
        {          
            get { return _architectures; }
            set { Set(() => Architectures, ref _architectures, value); }
        }

        public ArchitectureModel Architecture
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

            var architecture = await _architecturesManager.GetArchitectureById(Architecture.Id);
            if (architecture == null)
                return;

            await _sourcesManager.UpdateSource(source);

            Architectures.Add(architecture);

            ArchitecturesList.Remove(architecture);
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

            await _architectureSourceManager.RemoveArchitectureSource(architecture.Id, source.Id);

            source.ArchitecturesSources.Remove(ArchSour);
          
            await _sourcesManager.UpdateSource(source);

            Architectures.Remove(architecture);

            ArchitecturesList.Add(architecture);
        }

        public ObservableCollection<ArchitectureModel> SuggestBox_TextChanged(string text)
        {
           return new ObservableCollection<ArchitectureModel>(
               ArchitecturesList.Where(i => i.Title.ToLower().Contains(text)));
        }
    }
}
