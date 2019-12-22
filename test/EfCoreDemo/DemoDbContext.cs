using FlowMe.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo
{
    public class DemoDbContext : BpmnDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=47.102.133.59;database=FLOW_ME;user=root;password=h17621493149H");
        }
    }
}