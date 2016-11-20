using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using ArchitectureModel = Architecture.Data.Entities.Architecture;


namespace Architecture.Presentation.ViewModels.Architecture
{
    public class ArchitectureMainViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IArchitecturesManager _architecturesManager;

        private ObservableCollection<ArchitectureModel> _architectures;
        private ArchitectureModel _selectedTableItem;

        public ArchitectureMainViewModel(IArchitecturesManager architecturesManager)
        {
            _architecturesManager = architecturesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectureInternal");

            LoadData();
        }

        public ObservableCollection<ArchitectureModel> ArchitectureList
        {
            get { return _architectures; }
            set { Set(() => ArchitectureList, ref _architectures, value); }
        }

        public ArchitectureModel SelectedTableItem
        {
            get { return _selectedTableItem; }
            set { Set(() => SelectedTableItem, ref _selectedTableItem, value); }
        }

        public void EditArchitecture(ArchitectureModel itemToEdit)
        {
            _customNavigationService.NavigateTo(PageKeys.ArchitectureAdd, itemToEdit);
        }

        public async Task DeleteArchitecture(object architecture)
        {
            var arch = architecture as ArchitectureModel;

            if (arch == null)
                return;

            await _architecturesManager.RemoveArchitecture(arch.Id);

            ArchitectureList.Remove(arch);
        }

        private async void LoadData()
        {
            ArchitectureList = new ObservableCollection<ArchitectureModel>(await _architecturesManager.GetArchitectures());
        }
    }
}
