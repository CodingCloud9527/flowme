using FlowMe.Engine.Operation.Definition.Deployment;

namespace FlowMe.Engine.Operation.Definition
{
    public class DefOp : OperationBase,IDefOp
    {
        
        public DefOp(ProcessEngineConfiguration configuration) : base(configuration)
        {
        }
        public DeploymentBuilder CreateDeployment()
        {
            return new DeploymentBuilder(_configuration);
        }

       
    }
}