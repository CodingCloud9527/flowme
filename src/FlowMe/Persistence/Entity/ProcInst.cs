using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_PROC_INST")]
    public class ProcInst : GuidEntity
    {
        public ProcDef ProcDefRef { get; set; }

        [Required]
        [StringLength(50)]
        public string StartUser { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? FinishTime { get; set; }
    }
}