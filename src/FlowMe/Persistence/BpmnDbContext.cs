using FlowMe.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace FlowMe.Persistence
{
    public class BpmnDbContext : DbContext
    {
        public DbSet<ProcessDeployment> ProcessDeployments { get; set; }
        public DbSet<ProcessDefinition> ProcessDefs { get; set; }
        public DbSet<ProcessInstance> ProcessInstances { get; set; }
        public DbSet<ProcessExecution> ProcessExecutions { get; set; }
        public DbSet<ProcessTask> ProcessTasks { get; set; }
        public DbSet<ProcessVariable> ProcessVariables { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<ActHistory> ActHistories { get; set; }
        public DbSet<VariableHistory> VariableHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessDeployment>()
                .HasAlternateKey(p => p.Name);
        }
    }
}