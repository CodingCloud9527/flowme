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
            return new DeploymentBuilder(_configuration);
        }
    }
}