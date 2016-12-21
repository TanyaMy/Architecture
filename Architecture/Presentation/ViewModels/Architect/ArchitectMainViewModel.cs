using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ArchitectModel = Architecture.Data.Entities.Architect;

namespace Architecture.Presentation.ViewModels.Architect
{
    public class ArchitectMainViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IArchitectManager _architectsManager;

        private ObservableCollection<ArchitectModel> _architects;
        private ArchitectModel _selectedTableItem;

        public ArchitectMainViewModel(IArchitectManager architectsManager)
        {
            _architectsManager = architectsManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ArchitectInternal");

            LoadData();
        }

        public IList<ArchitectModel> FilteredArchitectsList { get; set; }

        public ObservableCollection<ArchitectModel> ArchitectList
        {
            get { return _architects; }
            set { Set(() => ArchitectList, ref _architects, value); }
        }

        public ArchitectModel SelectedTableItem
        {
            get { return _selectedTableItem; }
            set { Set(() => SelectedTableItem, ref _selectedTableItem, value); }
        }

        public void EditArchitect(ArchitectModel itemToEdit)
        {
            _customNavigationService.NavigateTo(PageKeys.ArchitectAdd, itemToEdit);
        }

        public async Task DeleteArchitect(object architect)
        {
            var arch = architect as ArchitectModel;

            if (arch == null)
                return;

            await _architectsManager.RemoveArchitect(arch.Id);

            ArchitectList.Remove(arch);
        }

        public void FilterCollection(string filteringSubstring)
        {
            filteringSubstring = filteringSubstring.Trim().ToLower();

            if (string.IsNullOrEmpty(filteringSubstring))
            {
                FilteredArchitectsList.Clear();
                return;
            }

            FilteredArchitectsList = ArchitectList.Where(x =>
                    x.Surname.ToLower().Contains(filteringSubstring)).ToList();
        }

        private async void LoadData()
        {
            ArchitectList = new ObservableCollection<ArchitectModel>(await _architectsManager.GetArchitects());
        }
    }
}
