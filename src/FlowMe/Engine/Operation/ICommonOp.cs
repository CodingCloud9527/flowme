using FlowMe.Event.Bus;

namespace FlowMe.Engine.Operation
{
    public interface ICommonOp
    {
        IEventDispatcher EventDispatcher { get; }
    }
}