using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_HI_PROCINST（")]
    public class ProcessInstance
    {
        [Key]
        [StringLength(64)]
        public string Id { get; set; }

        [StringLength(255)]
        public string BusinessKey { get; set; }

        [Required]
        public ProcessDefinition ProcessDef { get; set; }


        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public long? Duration { get; set; }

        [StringLength(255)]
        public string StartUserId { get; set; }

        [Required]
        [StringLength(255)]
        public string StartActId { get; set; }

        [StringLength(255)]
        public string EndActId { get; set; }

        public ProcessInstance ParentInstance { get; set; }
        
    }
}