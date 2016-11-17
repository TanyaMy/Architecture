using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleFilterViewModel : ViewModelBase
    {
        private readonly IStylesManager _stylesManager;

        private string _title;
        private string _motherCountry;
        private string _era;

        public StyleFilterViewModel(IStylesManager stylesManager)
        {
            _stylesManager = stylesManager;

            //FilterCommand = ;
        }

        public ICommand FilterCommand { get; }


        public string Title
        {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }

        public string MotherCountry
        {
            get { return _motherCountry; }
            set { Set(() => MotherCountry, ref _motherCountry, value); }
        }

        public string Era
        {
            get { return _era; }
            set { Set(() => Era, ref _era, value); }
        }
    }
}
