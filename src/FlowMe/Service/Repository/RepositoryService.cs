using FlowMe.ConcreteCommand.Deployment;
using FlowMe.Engine.Configuration;

namespace FlowMe.Service.Repository
{
    public class RepositoryService : ServiceBase, IRepositoryService
    {
        public RepositoryService(ProcessEngineConfiguration configuration) : base(configuration)
        {
        }

        public DeploymentBuilder CreateDeployment()
        {
            return CommandExecutor.Execute(new CreateDeploymentCmd());
        }
    }
}