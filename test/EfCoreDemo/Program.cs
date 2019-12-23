using System.IO;
using FlowMe.Engine;
using FlowMe.Engine.Configuration;

namespace EfCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bpmnContent = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "sample.xml"));
            var demoDbContext = new DemoDbContext();
            var processEngine = ProcessEngineFactory.Instance.Create(new ProcessEngineConfiguration {DbContext = demoDbContext});
            processEngine.RepositoryService.CreateDeployment()
                .Key("demokey")
                .Name("demoname")
                .BpmnContent(bpmnContent)
                .Deploy();
        }
    }
}