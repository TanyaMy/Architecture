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
        
        public ArchitectViewModel Architect => GetViewModel<ArchitectViewModel>();
        public ArchitectMainViewModel ArchitectMain => GetViewModel<ArchitectMainViewModel>();
        public ArchitectAddViewModel ArchitectAdd => GetViewModel<ArchitectAddViewModel>();

        public StyleViewModel Style => GetViewModel<StyleViewModel>();
        public StyleMainViewModel StyleMain => GetViewModel<StyleMainViewModel>();       
        public StyleAddViewModel StyleAdd => GetViewModel<StyleAddViewModel>();

        public SourceViewModel Source => GetViewModel<SourceViewModel>();
        public SourceMainViewModel SourceMain => GetViewModel<SourceMainViewModel>();
        public SourceAddViewModel SourceAdd => GetViewModel<SourceAddViewModel>();

        public RestorationMainViewModel RestorationMain => GetViewModel<RestorationMainViewModel>();
        public RestorationUpdateViewModel RestorationUpdate => GetViewModel<RestorationUpdateViewModel>();

        public RepairViewModel Repair => GetViewModel<RepairViewModel>();
        public RepairMainViewModel RepairMain => GetViewModel<RepairMainViewModel>();        
        public RepairAddViewModel RepairAdd => GetViewModel<RepairAddViewModel>();
        public RepairAutomatisationViewModel RepairAutomatisation => GetViewModel<RepairAutomatisationViewModel>();


        private T GetViewModel<T>()
        {
            return ServiceLocator.Current.GetInstance<T>(Guid.NewGuid().ToString());
        }
    }
}
