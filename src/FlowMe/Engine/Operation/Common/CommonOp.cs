using FlowMe.Event.Dispatcher;

namespace FlowMe.Engine.Operation.Common
{
    internal class CommonOp : OperationBase, ICommonOp
    {
        public CommonOp(ProcessEngineConfiguration configuration) : base(configuration)
        {
        }

        public IEventDispatcher EventDispatcher => _configuration.EventDispatcher;
    }
}