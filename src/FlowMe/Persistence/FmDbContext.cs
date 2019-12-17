using FlowMe.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace FlowMe.Persistence
{
    public class BpmnDbContext : DbContext
    {
        public DbSet<ProcDef> ProcDefs { get; set; }
        
        public DbSet<ProcInst> ProcInsts { get; set; }

        public DbSet<ProcTask> ProcTasks { get; set; }

        public DbSet<ProcVar> ProcVars { get; set; }
        
    }
}