using System;
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

            
        public ArchitectureViewModel Architecture => GetViewModel<ArchitectureViewModel>();
        public ArchitectureMainViewModel ArchitectureMain => GetViewModel<ArchitectureMainViewModel>();
        public ArchitectureAddViewModel ArchitectureAdd => GetViewModel<ArchitectureAddViewModel>();
        public ArchitectureReportsViewModel ArchitectureReports => GetViewModel<ArchitectureReportsViewModel>();
        public ArchitectureStatisticsViewModel ArchitectureStatistics => GetViewModel<ArchitectureStatisticsViewModel>();
        
        public ArchitectMainViewModel ArchitectMain => GetViewModel<ArchitectMainViewModel>();
        public ArchitectSearchViewModel ArchitectSearch => GetViewModel<ArchitectSearchViewModel>();
        public ArchitectFilterViewModel ArchitectFilter => GetViewModel<ArchitectFilterViewModel>();
        public ArchitectAddViewModel ArchitectAdd => GetViewModel<ArchitectAddViewModel>();
        public ArchitectUpdateViewModel ArchitectUpdate => GetViewModel<ArchitectUpdateViewModel>();

        public StyleMainViewModel StyleMain => GetViewModel<StyleMainViewModel>();
        public StyleSearchViewModel StyleSearch => GetViewModel<StyleSearchViewModel>();
        public StyleFilterViewModel StyleFilter => GetViewModel<StyleFilterViewModel>();
        public StyleAddViewModel StyleAdd => GetViewModel<StyleAddViewModel>();
        public StyleUpdateViewModel StyleUpdate => GetViewModel<StyleUpdateViewModel>();

        public SourceMainViewModel SourceMain => GetViewModel<SourceMainViewModel>();
        public SourceSearchViewModel SourceSearch => GetViewModel<SourceSearchViewModel>();
        public SourceFilterViewModel SourceFilter => GetViewModel<SourceFilterViewModel>();
        public SourceAddViewModel SourceAdd => GetViewModel<SourceAddViewModel>();
        public SourceUpdateViewModel SourceUpdate => GetViewModel<SourceUpdateViewModel>();

        public RestorationSearchViewModel RestorationSearch => GetViewModel<RestorationSearchViewModel>();
        public RestorationUpdateViewModel RestorationUpdate => GetViewModel<RestorationUpdateViewModel>();

        public RepairMainViewModel RepairMain => GetViewModel<RepairMainViewModel>();
        public RepairSearchViewModel RepairSearch => GetViewModel<RepairSearchViewModel>();
        public RepairFilterViewModel RepairFilter => GetViewModel<RepairFilterViewModel>();
        public RepairAddViewModel RepairAdd => GetViewModel<RepairAddViewModel>();
        public RepairUpdateViewModel RepairUpdate => GetViewModel<RepairUpdateViewModel>();
        public RepairAutomatisationViewModel RepairAutomatisation => GetViewModel<RepairAutomatisationViewModel>();


        private T GetViewModel<T>()
        {
            return ServiceLocator.Current.GetInstance<T>(Guid.NewGuid().ToString());
        }
    }
}
