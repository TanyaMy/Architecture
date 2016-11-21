using System.Windows.Input;
using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using Architecture.Presentation.Helpers.Interfaces;
using RestorationModel = Architecture.Data.Entities.Restoration;
using Microsoft.Practices.ServiceLocation;
using Architecture.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Presentation.ViewModels.Restoration
{
    public class RestorationUpdateViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IRestorationsManager _restorationManager;

        private readonly RestorationModel _restoration;

        private RestorationKind _restorationKind;
        private string _periodicity;
        private double _outlays;
      

        public RestorationUpdateViewModel(IRestorationsManager restorationManager)
        {
            _restorationManager = restorationManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("RepairInternal");

            _restoration = _customNavigationService.CurrentPageParams as RestorationModel;

            SaveChangesCommand = new RelayCommand(async () => await UpdateRestoration());

            ActionText = "Редактирование";
            ButtonText = "Сохранить изменения";

            InitData();
            SetupFields();

        }       

        public ICommand SaveChangesCommand { get; }

        public string ActionText { get; }
        public string ButtonText { get; }
        public List<RestorationKind> RestorationKindsList { get; private set; }

        private void InitData()
        {
            RestorationKindsList = Enum.GetValues(typeof(RestorationKind)).Cast<RestorationKind>().ToList();
        }

        public RestorationKind RestorationKind
        {
            get { return _restorationKind; }
            set { Set(() => RestorationKind, ref _restorationKind, value); }
        }       

        public string Periodicity
        {
            get { return _periodicity; }
            set { Set(() => Periodicity, ref _periodicity, value); }
        }

        public double Outlays
        {
            get { return _outlays; }
            set { Set(() => Outlays, ref _outlays, value); }
        }

        private async Task UpdateRestoration()
        {
            _restoration.RestorationKind = RestorationKind;
            _restoration.Periodicity = Periodicity;
            _restoration.Outlays = Outlays;

            await _restorationManager.UpdateRestoration(_restoration);

            _customNavigationService.NavigateTo(PageKeys.RestorationMain);
        }

        private void SetupFields()
        {
            RestorationModel editableRestor = _restoration;

            RestorationKind = editableRestor?.RestorationKind ?? RestorationKind.Restoration1;
            Periodicity = editableRestor?.Periodicity ?? "1 раз в год";
            Outlays = editableRestor?.Outlays ?? 0;
        }
    }
}
