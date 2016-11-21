using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.Models;
using Arcitecture.Presentation.ViewModels.Common;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System.Threading.Tasks;
using System.Windows.Input;
using StyleModel = Architecture.Data.Entities.Style;

namespace Architecture.Presentation.ViewModels.Style
{
    public class StyleAddViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IStylesManager _stylesManager;

        private readonly StyleModel _style;

        private string _title;
        private string _motherCountry;
        private string _era;

        public StyleAddViewModel(IStylesManager stylesManager)
        {
            _stylesManager = stylesManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("StyleInternal");

            _style = _customNavigationService.CurrentPageParams as StyleModel;

            SaveCommand = _style == null
             ? new RelayCommand(async () => await AddStyle())
             : new RelayCommand(async () => await UpdateStyle());

            ActionText = _style == null ? "Добавление" : "Редактирование";
            ButtonText = _style == null ? "Добавить" : "Сохранить изменения";

            SetupFields();
        }

        public ICommand SaveCommand { get; }

        public string ActionText { get; }
        public string ButtonText { get; }

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

        private async Task AddStyle()
        {
            var style = new StyleModel(Title, MotherCountry, Era);               

            await _stylesManager.AddStyle(style);

            _customNavigationService.NavigateTo(PageKeys.StyleMain);
        }

        private async Task UpdateStyle()
        {
            _style.Title = Title;
            _style.MotherCountry = MotherCountry;
            _style.Era = Era;

            await _stylesManager.UpdateStyle(_style);

            _customNavigationService.NavigateTo(PageKeys.StyleMain);
        }

        private void SetupFields()
        {
            StyleModel editableStyle = _style;

            Title = editableStyle?.Title ?? string.Empty;
            MotherCountry = editableStyle?.MotherCountry ?? string.Empty;
            Era = editableStyle?.Era ?? string.Empty;
        }
    }
}
