using FlowMe.Engine.Operation.Definition.Deployment;

namespace FlowMe.Engine.Operation
{
    public interface IDefOp
    {
        DeploymentBuilder CreateDeployment();
    }
}