using FlowMe.ConcreteCommand.Deployment;

namespace FlowMe.Service
{
    public interface IRepositoryService
    {
        DeploymentBuilder CreateDeployment();
    }
}