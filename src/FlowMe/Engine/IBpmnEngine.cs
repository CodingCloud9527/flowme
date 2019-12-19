using FlowMe.Engine.Operation;

namespace FlowMe.Engine
{
    public interface IBpmnEngine
    {
        ITaskOp TaskOp { get; }
        IRuntimeOp RuntimeOp { get; }
        IHisOp HisOp { get; }
        IDeployOp DeployOp { get; }
    }
}