using FlowMe.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace FlowMe.Persistence
{
    public class BpmnDbContext : DbContext
    {
        public DbSet<ProcessDeployment> ProcessDeployments { get; set; }
        public DbSet<ProcessDefinition> ProcessDefs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessDeployment>()
                .HasAlternateKey(p => p.Name);
            
        }
    }
}