using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    [Table("FM_RE_DEPLOYMENT")]
    public class ProcessDeployment
    {
        [Key]
        [StringLength(64)]
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Category { get; set; }

        public DateTime DeployTime { get; set; }
    }
}