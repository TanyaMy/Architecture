using System.Linq;
using Arcitecture.Presentation.ViewModels.Common;
using SourceModel = Architecture.Data.Entities.Source;
using ArchitectureModel = Architecture.Data.Entities.Architecture;
using ArchitectureSourceModel = Architecture.Data.Entities.ArchitectureSource;
using Architecture.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Presentation.Helpers.Interfaces;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using System;
using Architecture.Presentation.Models;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Architecture.Presentation.ViewModels.Source
{
    public class SourceMainViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly ISourcesManager _sourcesManager;

        private ObservableCollection<SourceModel> _sources;
        private SourceModel _selectedTableItem;

        private void ArchitectureListHandler(IList<ArchitectureModel> architecture) { }

        public SourceMainViewModel(ISourcesManager sourcesManager)
        {
            _sourcesManager = sourcesManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("SourceInternal");

         //   ShowArchitectures = new RelayCommand<IList<ArchitectureModel>>( x => ArchitectureListHandler(x));

            LoadData();
        }
        
        public ObservableCollection<SourceModel> SourceList
        {
            get { return _sources; }
            set { Set(() => SourceList, ref _sources, value); }
        }

       // public ICommand ShowArchitectures { get; set; }        


        public async Task DeleteSource(object source)
        {
            var sourc = source as SourceModel;

            if (sourc == null)
                return;

            await _sourcesManager.RemoveSource(sourc.Id);           

            SourceList.Remove(sourc);
        }

        public SourceModel SelectedTableItem
        {
            get { return _selectedTableItem; }
            set { Set(() => SelectedTableItem, ref _selectedTableItem, value); }
        }

        public void EditSource(SourceModel itemToEdit)
        {
            _customNavigationService.NavigateTo(PageKeys.SourceAdd, itemToEdit);
        }

        public void EditArchitectureSource(SourceModel itemToEdit)
        {
            _customNavigationService.NavigateTo(PageKeys.SourceAddArchitecture, itemToEdit);
        }

        public void ShowArchitectures(SourceModel item)
        {
            _customNavigationService.NavigateTo(PageKeys.SourceAddArchitecture, item);
        }

        public void AddArchitectureSource(SourceModel itemToAdd)
        {
            _customNavigationService.NavigateTo(PageKeys.SourceAddArchitecture, itemToAdd);
        }

        private async void LoadData()
        {
            SourceList = new ObservableCollection<SourceModel>(await _sourcesManager.GetSources());
        }
    }
}
