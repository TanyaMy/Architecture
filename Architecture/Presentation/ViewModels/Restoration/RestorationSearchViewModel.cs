using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Restoration
{
    public class RestorationSearchViewModel : ViewModelBase
    {
        private readonly IRestorationsManager _restorationsManager;

        private RestorationKind _restorationKind;

        public RestorationSearchViewModel(IRestorationsManager restorationsManager)
        {
            _restorationsManager = restorationsManager;

            //FindCommand = 

            InitData();
        }


        public ICommand FindCommand { get; }

        private void InitData()
        {
           RestorationKindsList = Enum.GetValues(typeof(RestorationKind)).Cast<RestorationKind>().ToList();
        }

        public RestorationKind RestorationKind
        {
            get { return _restorationKind; }
            set { Set(() => RestorationKind, ref _restorationKind, value); }
        }

        public List<RestorationKind> RestorationKindsList { get; private set; }
    }
}
