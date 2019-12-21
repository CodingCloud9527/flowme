using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_RU_VARIABLE")]
    public class ProcessVariable
    {
        [Key] [StringLength(64)] public string Id { get; set; }

        [Required] public ProcessInstance Instance { get; set; }

        [Required] public ProcessExecution Execution { get; set; }

        public ProcessTask Task { get; set; }

        [Required] [StringLength(255)] public string Name { get; set; }

        [Required] [StringLength(255)] public string Type { get; set; }

        [Required] [StringLength(2048)] public string Value { get; set; }
    }
}