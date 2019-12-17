using System;
using System.ComponentModel.DataAnnotations;

namespace FlowMe.Persistence.Entity
{
    public abstract class GuidEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}