using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_PROC_VAR")]
    public class ProcVar : GuidEntity
    {
        public ProcInst ProcInstRef { get; set; }

        [Required]
        [StringLength(1000)]
        public string JsonVar { get; set; }

        public string VarType { get; set; }
    }
}