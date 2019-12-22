using FlowMe.Command;
using FlowMe.Command.Context;

namespace FlowMe.ConcreteCommand.Deployment
{
    public class CreateDeploymentCmd : ICommand<DeploymentBuilder>
    {
        public DeploymentBuilder Execute(CommandContext commandContext)
        {
            return new DeploymentBuilder(commandContext.Configuration.DbContext);
        }
    }
}