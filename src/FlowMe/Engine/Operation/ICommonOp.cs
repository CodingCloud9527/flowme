using FlowMe.Event.Dispatcher;

namespace FlowMe.Engine.Operation
{
    public interface ICommonOp
    {
        IEventDispatcher EventDispatcher { get; }
    }
}