using System;
using System.ComponentModel.DataAnnotations;

namespace FlowMe.Persistence.Entity
{
    public class ProcTask : GuidEntity
    {
        public ProcInst ProcInstRef { get; set; }

        [Required]
        [StringLength(200)]
        public string TaskName { get; set; }

        [Required]
        [StringLength(100)]
        public string TaskType { get; set; }

        public DateTime ReceiveTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Receiver { get; set; }

        public string Executor { get; set; }

        public DateTime? CompleteTime { get; set; }
    }
}