using FlowMe.Engine.Operation;
using FlowMe.Engine.Operation.Common;
using FlowMe.Engine.Operation.Definition;

namespace FlowMe.Engine
{
    public class ProcessEngine : IProcessEngine
    {
        private readonly ProcessEngineConfiguration _configuration;

        public ProcessEngine(ProcessEngineConfiguration configuration)
        {
            _configuration = configuration;
        }


        public ITaskOp TaskOp { get; }
        public IRuntimeOp RuntimeOp { get; }
        public IHisOp HisOp { get; }
        public IDefOp DefOp => new DefOp(_configuration);
        public ICommonOp CommonOp => new CommonOp(_configuration);
    }
}