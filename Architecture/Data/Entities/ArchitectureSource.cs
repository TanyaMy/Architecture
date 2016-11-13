using System.ComponentModel.DataAnnotations;

namespace Architecture.Data.Entities
{
    public class ArchitectureSource
    {
        [Key]
        public int ArchitectureId { get; set; }
        public Architecture Architecture { get; set; }

        [Key]
        public int SourceId { get; set; }
        public Source Source { get; set; }
    }
}
