using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_RU_TASK")]
    public class ProcessTask
    {
        [Key]
        [StringLength(64)]
        public string Id { get; set; }

        [Required]
        public ProcessExecution Execution { get; set; }

        [Required]
        public ProcessInstance Instance { get; set; }

        [Required]
        public ProcessDefinition Definition { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public TaskHistory ParentTask { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string TaskDefId { get; set; }


        [StringLength(255)]
        public string Assignee { get; set; }

        [StringLength(255)]
        public string Group { get; set; }

        [StringLength(255)]
        public string Owner { get; set; }

        public int Priority { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? DueTime { get; set; }

        public bool IsActive { get; set; }
    }
}