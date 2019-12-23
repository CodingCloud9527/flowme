using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_HI_TASKINST")]
    public class TaskHistory
    {
        [Key]
        [StringLength(64)]
        public string Id { get; set; }

        [Required]
        public ProcessDefinition Definition { get; set; }

        [Required]
        [StringLength(255)]
        public string TaskDefId { get; set; }

        [Required]
        public ProcessInstance Instance { get; set; }

        [Required]
        public ProcessExecution Execution { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public TaskHistory Task { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Owner { get; set; }

        [Required]
        [StringLength(255)]
        public string Assignee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime? ClaimTime { get; set; }

        public long Duration { get; set; }

        [StringLength(1000)]
        public string DeleteReason { get; set; }

        public int Priority { get; set; }

        public DateTime? DueTime { get; set; }

        [StringLength(255)]
        public string FormKey { get; set; }
    }
}