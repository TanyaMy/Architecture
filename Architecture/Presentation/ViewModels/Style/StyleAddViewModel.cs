using Architecture.Managers.Interfaces;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleAddViewModel : ViewModelBase
    {
        private readonly IStylesManager _stylesManager;

        private string _title;
        private string _motherCountry;
        private string _era;

        public StyleAddViewModel(IStylesManager stylesManager)
        {
            _stylesManager = stylesManager;

            SaveCommand = new RelayCommand(async () => await SaveToDb());
        }

        public ICommand SaveCommand { get; }


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

        private async Task SaveToDb()
        {
            var style = new Data.Entities.Style(Title, MotherCountry, Era);

            await _stylesManager.AddStyle(style);
        }
    }
}
