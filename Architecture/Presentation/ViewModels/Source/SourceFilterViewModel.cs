using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Source
{
    public class SourceFilterViewModel : ViewModelBase
    {
        private readonly ISourcesManager _sourcesManager;

        private SourceKind _sourceKind;
        private string _title;
        private string _author;
        private int _creationYear;


        public SourceFilterViewModel(ISourcesManager sourcesManager)
        {
            _sourcesManager = sourcesManager;

            //FilterCommand = 

            InitData();
        }

        private void InitData()
        {
            SourceKindsList = Enum.GetValues(typeof(SourceKind)).Cast<SourceKind>().ToList();
        }

        public ICommand FilterCommand { get; }

        public List<SourceKind> SourceKindsList { get; private set; }

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
    }
}
