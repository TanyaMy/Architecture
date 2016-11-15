using System;
using Architecture.Presentation.Views;
using Architecture.Presentation.Views.Architect;
using Architecture.Presentation.Views.Architecture;
using Architecture.Presentation.Views.Style;
using ArchitectAddPage = Architecture.Presentation.Views.Architect.ArchitectAddPage;
using SourceMainPage = Architecture.Presentation.Views.Source.SourceMainPage;

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
        SourceMain
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
