using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_RE_PROCDEF")]
    public class ProcessDefinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(255)]
        public string Category { get; set; }


        [Required]
        [StringLength(255)]
        public string Key { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public int Version { get; set; }


        [Required]
        public ProcessDeployment Deployment { get; set; }


        [Required]
        [StringLength(5000)]
        public string DefinitionXml { get; set; }


        [StringLength(5000)]
        public string Description { get; set; }
    }
}