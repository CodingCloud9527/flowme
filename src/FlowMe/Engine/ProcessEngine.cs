using FlowMe.Engine.Operation;

namespace FlowMe.Engine
{
    public class ProcessEngine : IProcessEngine
    {
        private ProcessEngineConfiguration _configuration;

        public ProcessEngine(ProcessEngineConfiguration configuration)
        {
            _configuration = configuration;
        }


        public ITaskOp TaskOp { get; }
        public IRuntimeOp RuntimeOp { get; }
        public IHisOp HisOp { get; }
        public IDeployOp DeployOp { get; }
    }
}