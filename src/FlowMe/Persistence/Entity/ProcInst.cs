using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_PROC_INST")]
    public class ProcInst : GuidEntity
    {
        [ForeignKey("PROC_DEF_REF")]
        public ProcDef ProcDefRef { get; set; }

        [Required]
        [StringLength(50)]
        [Column("START_USER")]
        public string StartUser { get; set; }

        [Column("START_TIME")]
        public DateTime StartTime { get; set; }

        [Column("FINISH_TIME")]
        public DateTime? FinishTime { get; set; }
    }
}