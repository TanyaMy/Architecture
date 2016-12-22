using System.Collections.Generic;

namespace Architecture.Data.Entities
{
    public enum SourceKind
    {
        Книга,
        Картина,
        Фильм,
        Музыка,
        Другое
    }

    public class Source
    {
        public Source()
        {
        }

        public Source(
            SourceKind sourceKind, 
            string title,
            string author, 
            int creationYear)
        {
            SourceKind = sourceKind;
            Title = title;
            Author = author;
            CreationYear = creationYear;
        }

        public int Id { get; set; }

        public SourceKind SourceKind { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int CreationYear { get; set; }

        public IList<ArchitectureSource> ArchitecturesSources { get; set; }
    }
}
