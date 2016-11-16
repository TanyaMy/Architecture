using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.ApplicationModel.Contacts;
using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Threading.Tasks;



namespace Architecture.Presentation.ViewModels.Restoration
{
    public class RestorationAddViewModel : ViewModelBase
    {
        private readonly IRestorationsManager _restorationManager;


        private RestorationKind _restorationKind;
        private string _periodicity;
        private double _outlays;
      

        public RestorationAddViewModel(IRestorationsManager restorationManager)
        {
            _restorationManager = restorationManager;

            SaveCommand = new RelayCommand(async () => await SaveToDb());
          
        }       

        public ICommand SaveCommand { get; }

      
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



        private async Task SaveToDb()
        {
            var restoration = new Data.Entities.Restoration(
               RestorationKind, Periodicity, Outlays);

            await _restorationManager.AddRestoration(restoration);
        }
    }
}
