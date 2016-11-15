using Architecture.Presentation.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace Arcitecture.Presentation.ViewModels.Common
{
    public class ViewModelLocator
    {
        public MainViewModel Main => GetViewModel<MainViewModel>();        
        public ArchitectureMainViewModel ArchitectureMain => GetViewModel<ArchitectureMainViewModel>();
        public ArchitectureSearchViewModel ArchitectureSearch => GetViewModel<ArchitectureSearchViewModel>();
        public ArchitectureFilterViewModel ArchitectureFilter => GetViewModel<ArchitectureFilterViewModel>();
        public ArchitectureAddViewModel ArchitectureAdd => GetViewModel<ArchitectureAddViewModel>();
        public ArchitectureReportsViewModel ArchitectureReports => GetViewModel<ArchitectureReportsViewModel>();
        public ArchitectureStatisticsViewModel ArchitectureStatistics => GetViewModel<ArchitectureStatisticsViewModel>();

        public ArchitectMainViewModel ArchitectMain => GetViewModel<ArchitectMainViewModel>();
        public ArchitectSearchViewModel ArchitectSearch => GetViewModel<ArchitectSearchViewModel>();
        public ArchitectFilterViewModel ArchitectFilter => GetViewModel<ArchitectFilterViewModel>();
        public ArchitectAddViewModel ArchitectAdd => GetViewModel<ArchitectAddViewModel>();

        public StyleMainViewModel StyleMain => GetViewModel<StyleMainViewModel>();

        public SourceMainViewModel SourceMain => GetViewModel<SourceMainViewModel>();

        public RestorationMainViewModel RestorationMain => GetViewModel<RestorationMainViewModel>();


        private T GetViewModel<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }
    }
}
