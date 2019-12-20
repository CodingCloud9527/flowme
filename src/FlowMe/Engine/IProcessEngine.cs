using FlowMe.Engine.Operation;

namespace FlowMe.Engine
{
    public interface IProcessEngine
    {
        ITaskOp TaskOp { get; }
        IRuntimeOp RuntimeOp { get; }
        IHisOp HisOp { get; }
        IDefOp DefOp { get; }

        ICommonOp CommonOp { get; }
    }
}