using FlowMe.Command;
using FlowMe.Command.Context;
using FlowMe.Service.Repository;

namespace FlowMe.ConcreteCommand.Deployment
{
    public class CreateDeploymentCmd : ICommand<DeploymentBuilder>
    {
        private readonly RepositoryService _repositoryService;

        public CreateDeploymentCmd(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public DeploymentBuilder Execute(CommandContext commandContext)
        {
            return new DeploymentBuilder(_repositoryService);
        }
    }
}