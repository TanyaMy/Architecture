using System;
using Architecture.Presentation.Views;
using Architecture.Presentation.Views.Architect;
using Architecture.Presentation.Views.Architecture;
using Architecture.Presentation.Views.Restoration;
using Architecture.Presentation.Views.Style;
using ArchitectAddPage = Architecture.Presentation.Views.Architect.ArchitectAddPage;
using SourceMainPage = Architecture.Presentation.Views.Source.SourceMainPage;
using Architecture.Presentation.Views.Repair;

namespace Architecture.Presentation.Models
{
    public enum PageKeys
    {
        [PageType(typeof(ArchitectureMainPage))]
        ArchitectureMain,
        [PageType(typeof(ArchitectureSearchPage))]
        ArchitectureSearch,
        [PageType(typeof(ArchitectureFilterPage))]
        ArchitectureFilter,
        [PageType(typeof(ArchitectureAddPage))]
        ArchitectureAdd,
        [PageType(typeof(ArchitectureReportsPage))]
        ArchitectureReports,
        [PageType(typeof(ArchitectureStatisticsPage))]
        ArchitectureStatistics,
        [PageType(typeof(ArchitectMainPage))]
        ArchitectMain,
        [PageType(typeof(ArchitectSearchPage))]
        ArchitectSearch,
        [PageType(typeof(ArchitectFilterPage))]
        ArchitectFilter,
        [PageType(typeof(ArchitectAddPage))]
        ArchitectAdd,
        [PageType(typeof(StyleMainPage))]
        StyleMain,
        [PageType(typeof(SourceMainPage))]
        SourceMain,
        [PageType(typeof(RestorationSearchPage))]
        RestorationSearch,        
        [PageType(typeof(RestorationUpdatePage))]
        RestorationUpdate,
        [PageType(typeof(RepairMainPage))]
        RepairMain,
        [PageType(typeof(RepairSearchPage))]
        RepairSearch,
        [PageType(typeof(RepairFilterPage))]
        RepairFilter,
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
