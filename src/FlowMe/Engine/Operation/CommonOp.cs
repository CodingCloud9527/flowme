using FlowMe.Event.Bus;

namespace FlowMe.Engine.Operation
{
    class CommonOp : OperationBase, ICommonOp
    {
        public IEventDispatcher EventDispatcher => _configuration.EventDispatcher;

        public CommonOp(ProcessEngineConfiguration configuration) : base(configuration)
        {
        }
    }
}