using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Model
{
    class ArchitectureSource
    {
        private int _sourceId;
        private int _architectureId;

        public int SourceId
        {
            get { return _sourceId; }
            set { _sourceId = value; }
        }

        public int ArchitectureId
        {
            get { return _architectureId; }
            set { _architectureId = value; }
        }

    }
}
