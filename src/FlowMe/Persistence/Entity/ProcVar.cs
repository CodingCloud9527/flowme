using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_PROC_VAR")]
    public class ProcVar : GuidEntity
    {
        [Column("PROC_INST_REF")] public ProcInst ProcInstRef { get; set; }

        [Required]
        [StringLength(20)]
        [Column("VAR_NAME")]
        public string VarName { get; set; }


        [Required]
        [StringLength(1000)]
        [Column("VAR_VALUE")]
        public string VarValue { get; set; }

        [Column("VAR_TYPE")] public string VarType { get; set; }
    }
}