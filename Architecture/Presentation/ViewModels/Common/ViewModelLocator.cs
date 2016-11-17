using Architecture.Presentation.ViewModels.Architect;
using Architecture.Presentation.ViewModels.Architecture;
using Architecture.Presentation.ViewModels.Repair;
using Architecture.Presentation.ViewModels.Restoration;
using Architecture.Presentation.ViewModels.Source;
using Architecture.Presentation.ViewModels.Style;
using Microsoft.Practices.ServiceLocation;

namespace Architecture.Presentation.ViewModels.Common
{
    public class ViewModelLocator
    {
        public ShellViewModel Shell => GetViewModel<ShellViewModel>();

            
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

        public RestorationSearchViewModel RestorationSearch => GetViewModel<RestorationSearchViewModel>();
        public RestorationUpdateViewModel RestorationUpdate => GetViewModel<RestorationUpdateViewModel>();

        public RepairMainViewModel RepairMain => GetViewModel<RepairMainViewModel>();
        public RepairSearchViewModel RepairSearch => GetViewModel<RepairSearchViewModel>();
        public RepairFilterViewModel RepairFilter => GetViewModel<RepairFilterViewModel>();
        public RepairAddViewModel RepairAdd => GetViewModel<RepairAddViewModel>();
        public RepairAutomatisationViewModel RepairAutomatisation => GetViewModel<RepairAutomatisationViewModel>();


        private T GetViewModel<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }
    }
}
