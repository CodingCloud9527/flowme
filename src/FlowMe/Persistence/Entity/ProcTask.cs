using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_PROC_TASK")]
    public class ProcTask : GuidEntity
    {
        [ForeignKey("PROC_INST_REF")]
        public ProcInst ProcInstRef { get; set; }

        [Required]
        [StringLength(200)]
        [Column("TASK_NAME")]
        public string TaskName { get; set; }

        [Required]
        [StringLength(100)]
        [Column("TASK_TYPE")]
        public string TaskType { get; set; }

        public DateTime ReceiveTime { get; set; }

        [Required]
        [StringLength(50)]
        [Column("RECEIVER")]
        public string Receiver { get; set; }

        [Column("EXECUTOR")]
        public string Executor { get; set; }

        [Column("COMPLETE_TIME")]
        public DateTime? CompleteTime { get; set; }
    }
}