using FlowMe.Command.Executor;
using FlowMe.Engine.Configuration;

namespace FlowMe.Service
{
    public abstract class ServiceBase
    {
        protected ServiceBase(ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ProcessEngineConfiguration Configuration { get; set; }

        protected ICommandExecutor CommandExecutor => Configuration.CommandExecutor;
    }
}