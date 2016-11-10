using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Presentation.Models
{
    public enum SourceKind
    {
        book,
        movie,
        picture
    }

    public class Source
    {
        private int _sourceId;
        private SourceKind _sourceKind;
        private string _title;
        private string _author;
        private int _creationYear;

        public Source (int sourseId,  SourceKind sourseKind, string title,
            string author, int creationYear)
        {
            _sourceId = sourseId;
            _sourceKind = sourseKind;
            _title = title;
            _author = author;
            _creationYear = creationYear;
        }

        public int SourceId
        {
            get { return _sourceId; }
            set { _sourceId = value; }
        }

        public SourceKind SourseKind
        {
            get { return _sourceKind; }
            set { _sourceKind = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public int CreationYear
        {
            get { return _creationYear; }
            set { _creationYear = value; }
        }
    }
}
