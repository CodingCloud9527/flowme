using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_HI_ACT")]
    public class ActHistory
    {
        [Key] [StringLength(64)] public string Id { get; set; }

        [Required] public ProcessDefinition Definition { get; set; }

        [Required] public ProcessInstance Instance { get; set; }

        [Required] public ProcessExecution Execution { get; set; }

        [Required] [StringLength(255)] public string ActDefId { get; set; }

        public ProcessTask Task { get; set; }


        public ProcessInstance CallInstance { get; set; }

        [Required] [StringLength(255)] public string ActName { get; set; }

        [Required] [StringLength(255)] public string ActType { get; set; }

        [Required] [StringLength(255)] public string Assignee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public long Duration { get; set; }
    }
}