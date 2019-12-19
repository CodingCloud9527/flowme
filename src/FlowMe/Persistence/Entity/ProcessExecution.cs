using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_RU_EXECUTION")]
    public class ProcessExecution
    {
        [Key]
        [StringLength(64)]
        public string Id { get; set; }

        [Required]
        public ProcessInstance Instance { get; set; }

        [StringLength(255)]
        public string BusinessKey { get; set; }

        public ProcessExecution ParentExecution { get; set; }

        [Required]
        public ProcessDefinition Definition { get; set; }

        // public ActHistory Act { get; set; }

        public bool IsActive { get; set; }

        public bool IsConcurrent { get; set; }
    }
}