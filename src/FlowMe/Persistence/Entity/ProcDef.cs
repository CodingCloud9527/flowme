using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_PROC_DEF")]
    public class ProcDef : GuidEntity
    {
        [Required]
        [StringLength(5000)]
        [Column("BPMN_DEF_CONTENT")]
        public string BpmnDefContent { get; set; }


        [MaxLength(5)]
        [Column("VERSION")]
        public int Version { get; set; }

        [Column("ENABLE")]
        public bool Enable { get; set; }

        [Required]
        [StringLength(200)]
        [Column("PROC_NAME")]
        public string ProcName { get; set; }

        [StringLength(2000)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}