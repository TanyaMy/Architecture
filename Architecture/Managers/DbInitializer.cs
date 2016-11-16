using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Managers.Interfaces;
using Microsoft.Practices.ServiceLocation;
using ArchitectureModel = Architecture.Data.Entities.Architecture;

namespace Architecture.Managers
{
    public static class DbInitializer
    {
        private static readonly IRestorationManager _architectsManager;
        private static readonly IArchitecturesManager _architecturesManager;
        private static readonly IRepairsManager _repairsManager;
        private static readonly IRestorationsManager _restorationsManager;
        private static readonly ISourcesManager _sourcesManager;
        private static readonly IStylesManager _stylesManager;

        static DbInitializer()
        {
            _architectsManager = ServiceLocator.Current.GetInstance<IRestorationManager>();
            _architecturesManager = ServiceLocator.Current.GetInstance<IArchitecturesManager>();
            _repairsManager = ServiceLocator.Current.GetInstance<IRepairsManager>();
            _restorationsManager = ServiceLocator.Current.GetInstance<IRestorationsManager>();
            _sourcesManager = ServiceLocator.Current.GetInstance<ISourcesManager>();
            _stylesManager = ServiceLocator.Current.GetInstance<IStylesManager>();
        }

        public static async Task Seed()
        {
            await FillArchitects();
            await FillStyles();
            await FillSources();
            await FillArchitectures();
            await FillRestorations();
            await FillRepairs();
        }

        private async static Task FillArchitects()
        {
            IList<Architect> architects = (await _architectsManager.GetArchitects()).ToList();

            if (architects != null && architects.Any())
                return;

            await _architectsManager.AddArchitect(
                new Architect("Джон", "Петров", "Ukraine", DateTime.Now.AddYears(-50), DateTime.Now));

            await _architectsManager.AddArchitect(
                new Architect("Андрей", "Столовый", "Russia", DateTime.Now.AddYears(-30), DateTime.Now));

            await _architectsManager.AddArchitect(
                new Architect("Кирилл", "Справочный", "Ukraine", DateTime.Now.AddYears(-50), DateTime.Now));

            await _architectsManager.AddArchitect(
                new Architect("Никита", "Цыбусов", "Ukraine", DateTime.Now.AddYears(-50), DateTime.Now));
        }

        private async static Task FillStyles()
        {
            IList<Style> styles = (await _stylesManager.GetStyles()).ToList();

            if (styles != null && styles.Any())
                return;

            await _stylesManager.AddStyle(new Style("Style1", "Russia", "Kakaya-to1"));
            await _stylesManager.AddStyle(new Style("Style2", "Ukraine", "Kakaya-to2"));
            await _stylesManager.AddStyle(new Style("Style3", "Russia", "Kakaya-to3"));
            await _stylesManager.AddStyle(new Style("Style4", "Russia", "Kakaya-to4"));
            await _stylesManager.AddStyle(new Style("Style5", "Ukraine", "Kakaya-to5"));
            await _stylesManager.AddStyle(new Style("Style6", "Russia", "Kakaya-to6"));

        }

        private async static Task FillSources()
        {
            IList<Source> sources = (await _sourcesManager.GetSources()).ToList();

            if (sources != null && sources.Any())
                return;

            await _sourcesManager.AddSource(new Source(SourceKind.Picture, "Source1", "Author1", 1817));
            await _sourcesManager.AddSource(new Source(SourceKind.Movie, "Source2", "Author2", 1818));
            await _sourcesManager.AddSource(new Source(SourceKind.Book, "Source3", "Author3", 1928));
            await _sourcesManager.AddSource(new Source(SourceKind.Movie, "Source4", "Author4", 1543));
            await _sourcesManager.AddSource(new Source(SourceKind.Picture, "Source5", "Author5", 1991));
            await _sourcesManager.AddSource(new Source(SourceKind.Picture, "Source6", "Author6", 1000));
            await _sourcesManager.AddSource(new Source(SourceKind.Book, "Source7", "Author7", 1122));
        }

        private async static Task FillArchitectures()
        {
            IList<ArchitectureModel> architectures = (await _architecturesManager.GetArchitectures()).ToList();
            IList<Architect> architects = (await _architectsManager.GetArchitects()).ToList();
            IList<Style> styles = (await _stylesManager.GetStyles()).ToList();

            if (architectures != null && architectures.Any())
                return;

            Random r = new Random();
            int stylesIndex1 = r.Next(0, styles.Count - 1),
                stylesIndex2 = r.Next(0, styles.Count - 1),
                stylesIndex3 = r.Next(0, styles.Count - 1);
            int architectsIndex1 = r.Next(0, architects.Count - 1),
                architectsIndex2 = r.Next(0, architects.Count - 1),
                architectsIndex3 = r.Next(0, architects.Count - 1);

            await _architecturesManager.AddArchitecture(new ArchitectureModel(
                "Architecture1", 1432, "Ukraine", "Kharkov", "Address1", 172, 272,
                State.Normal, architects[architectsIndex1].Id, styles[stylesIndex1].Id));

            await _architecturesManager.AddArchitecture(new ArchitectureModel(
                "Architecture2", 1112, "Ukraine", "Odessa", "Address2", 122, 112,
                State.Normal, architects[architectsIndex2].Id, styles[stylesIndex2].Id));

            await _architecturesManager.AddArchitecture(new ArchitectureModel(
                "Architecture3", 1453, "Ukraine", "Kharkov", "Address3", 144, 254,
                State.Normal, architects[architectsIndex3].Id, styles[stylesIndex3].Id));

            await _architecturesManager.AddArchitecture(new ArchitectureModel(
                "Architecture4", 1112, "Ukraine", "Kiev", "Address4", 123, 343,
                State.Normal, architects[architectsIndex1].Id, styles[stylesIndex3].Id));

            await _architecturesManager.AddArchitecture(new ArchitectureModel(
                "Architecture5", 1919, "Ukraine", "Kharkov", "Address5", 143, 123,
                State.Normal, architects[architectsIndex3].Id, styles[stylesIndex2].Id));

        }

        private async static Task FillRestorations()
        {
            IList<Restoration> restorations = (await _restorationsManager.GetRestorations()).ToList();

            if (restorations != null && restorations.Any())
                return;

            await _restorationsManager.AddRestoration(new Restoration(
                RestorationKind.Restoration1, "Test1", 11));
            await _restorationsManager.AddRestoration(new Restoration(
                RestorationKind.Restoration2, "Test2", 12));
            await _restorationsManager.AddRestoration(new Restoration(
                RestorationKind.Restoration3, "Test3", 144));

        }

        private async static Task FillRepairs()
        {
            IList<Repair> repairs = (await _repairsManager.GetRepairs()).ToList();

            if (repairs != null && repairs.Any())
                return;
            
            var architectures = (await _architecturesManager.GetArchitectures()).ToList();

            Random r = new Random();
            int architecturesIndex = r.Next(0, architectures.Count - 1);

            await _repairsManager.AddRepair(
                new Repair(
                    RestorationKind.Restoration1,
                    architectures[architecturesIndex].Id,
                    DateTime.Now.AddMonths(-20),
                    22222));
            await _repairsManager.AddRepair(
                new Repair(
                    RestorationKind.Restoration2,
                    architectures[architecturesIndex].Id,
                    DateTime.Now.AddMonths(-20),
                    22222));
            await _repairsManager.AddRepair(
                new Repair(
                    RestorationKind.Restoration3,
                    architectures[architecturesIndex].Id,
                    DateTime.Now.AddMonths(-20),
                    22222));
        }

    }
}
