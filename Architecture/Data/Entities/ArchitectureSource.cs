using System.ComponentModel.DataAnnotations;

namespace Architecture.Data.Entities
{
    public class ArchitectureSource
    {
        public int ArchitectureId { get; set; }
        public Architecture Architecture { get; set; }
        
        public int SourceId { get; set; }
        public Source Source { get; set; }
    }
}
