using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_PROC_DEF")]
    public class ProcDef : GuidEntity
    {
        [Required]
        [StringLength(5000)]
        public string BpmnDefContent { get; set; }


        [MaxLength(5)]
        public int Version { get; set; }

        public bool Enable { get; set; }

        [Required]
        [StringLength(200)]
        public string ProcName { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }
    }
}