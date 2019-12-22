using FlowMe.ConcreteCommand.Deployment;
using FlowMe.Engine.Configuration;

namespace FlowMe.Service.Repository
{
    public class RepositoryService : ServiceBase, IRepositoryService
    {
        public DeploymentBuilder CreateDeployment()
        {
            return CommandExecutor.Execute(new CreateDeploymentCmd());
        }

        public RepositoryService(ProcessEngineConfiguration configuration) : base(configuration)
        {
        }
    }
}