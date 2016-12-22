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
    public class SourceAddViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly ISourcesManager _sourcesManager;
        private readonly IArchitecturesManager _architecturesManager;

        private readonly SourceModel _source;
        private List<Data.Entities.Architecture> _architecturesList;

        private SourceKind _sourceKind;
        private string _title;
        private string _author;
        private int _creationYear;
        private Data.Entities.Architecture _architecture;


        public SourceAddViewModel(ISourcesManager sourcesManager, IArchitecturesManager architecturesManager)
        {
            _sourcesManager = sourcesManager;
            _architecturesManager = architecturesManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("SourceInternal");

            _source = _customNavigationService.CurrentPageParams as SourceModel;

            SaveCommand = _source == null
             ? new RelayCommand(async () => await AddSource())
             : new RelayCommand(async () => await UpdateSource());

            ActionText = _source == null ? "Добавление" : "Редактирование";
            ButtonText = _source == null ? "Добавить" : "Сохранить изменения";

            InitData();
            SetupFields();
        }

        private async void InitData()
        {
            ArchitecturesList = (await _architecturesManager.GetArchitectures()).ToList();
            SourceKindsList = Enum.GetValues(typeof(SourceKind)).Cast<SourceKind>().ToList();
        }

        public ICommand SaveCommand { get; }

        public string ActionText { get; }
        public string ButtonText { get; }

        public List<SourceKind> SourceKindsList { get; private set; }

        public List<Data.Entities.Architecture> ArchitecturesList
        {
            get { return _architecturesList; }
            set { Set(() => ArchitecturesList, ref _architecturesList, value); }
        }

        public SourceKind SourceKind
        {
            get { return _sourceKind; }
            set { Set(() => SourceKind, ref _sourceKind, value); }
        }
        
        public string Title
        {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }

        public string Author
        {
            get { return _author; }
            set { Set(() => Author, ref _author, value); }
        }

        public int CreationYear
        {
            get { return _creationYear; }
            set { Set(() => CreationYear, ref _creationYear, value); }
        }

        public Data.Entities.Architecture Architecture
        {
            get { return _architecture; }
            set { Set(() => Architecture, ref _architecture, value); }
        }

        private async Task AddSource()
        {
            var source = new SourceModel(SourceKind, Title, Author, CreationYear);

            source = await _sourcesManager.AddSource(source);           

            await _sourcesManager.UpdateSource(source);

            _customNavigationService.NavigateTo(PageKeys.SourceAddArchitecture, source);
        }

        private async Task UpdateSource()
        {
            _source.SourceKind = SourceKind;
            _source.Title = Title;
            _source.Author = Author;
            _source.CreationYear = CreationYear;         

            await _sourcesManager.UpdateSource(_source);

            _customNavigationService.NavigateTo(PageKeys.SourceMain);
        }

        private void SetupFields()
        {
            SourceModel editableSource = _source;

            SourceKind = editableSource?.SourceKind ?? SourceKind.Книга;
            Title = editableSource?.Title ?? string.Empty;
            Author = editableSource?.Author ?? "Неизвестен";
            CreationYear = editableSource?.CreationYear ?? 0;
        }
    }
}
