using FlowMe.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowMe.EFCore.Demo
{
    public class DemoDbContext : BpmnDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
}