using System;
using Architecture.Presentation.Views.Architect;
using Architecture.Presentation.Views.Architecture;
using Architecture.Presentation.Views.Restoration;
using Architecture.Presentation.Views.Style;
using Architecture.Presentation.Views.Repair;
using Architecture.Presentation.Views.Source;

namespace Architecture.Presentation.Models
{
    public enum PageKeys
    {
        [PageType(typeof(ArchitecturePage))]
        Architecture,
        [PageType(typeof(ArchitectureMainPage))]
        ArchitectureMain,
        [PageType(typeof(ArchitectureAddPage))]
        ArchitectureAdd,
        [PageType(typeof(ArchitectureReportsPage))]
        ArchitectureReports,
        [PageType(typeof(ArchitectureStatisticsPage))]
        ArchitectureStatistics,
        [PageType(typeof(ArchitectPage))]
        Architect,
        [PageType(typeof(ArchitectMainPage))]
        ArchitectMain,   
        [PageType(typeof(ArchitectAddPage))]
        ArchitectAdd,       
        [PageType(typeof(StylePage))]
        Style,
        [PageType(typeof(StyleMainPage))]
        StyleMain,  
        [PageType(typeof(StyleAddPage))]
        StyleAdd,       
        [PageType(typeof(SourcePage))]
        Source,
        [PageType(typeof(SourceMainPage))]
        SourceMain,       
        [PageType(typeof(SourceAddPage))]
        SourceAdd,       
        [PageType(typeof(RestorationMainPage))]
        RestorationMain,        
        [PageType(typeof(RestorationUpdatePage))]
        RestorationUpdate,
        [PageType(typeof(RepairPage))]
        Repair,
        [PageType(typeof(RepairMainPage))]
        RepairMain,       
        [PageType(typeof(RepairAddPage))]
        RepairAdd,       
        [PageType(typeof(RepairAutomatisationPage))]
        RepairAutomatisation
    }

    public class PageTypeAttribute : Attribute
    {
        public PageTypeAttribute(Type pageType)
        {
            PageType = pageType;
        }

        public Type PageType { get; private set; }
    }
}
