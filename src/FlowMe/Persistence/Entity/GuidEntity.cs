using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMe.Persistence.Entity
{
    public abstract class GuidEntity
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
    }
}