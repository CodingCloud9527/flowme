using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_HI_VARIABLE")]
    public class VariableHistory
    {
        [Key] [StringLength(64)] public string Id { get; set; }


        [Required] public ProcessInstance Instance { get; set; }

        [Required] public ProcessExecution Execution { get; set; }

        public TaskHistory Task { get; set; }

        [Required] [StringLength(255)] public string Name { get; set; }

        [Required] [StringLength(255)] public string Type { get; set; }

        [Required] [StringLength(2048)] public string Value { get; set; }
    }
}