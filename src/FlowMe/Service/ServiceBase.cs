using FlowMe.Command.Executor;
using FlowMe.Engine.Configuration;

namespace FlowMe.Service
{
    public abstract class ServiceBase
    {
        public ProcessEngineConfiguration Configuration { get; set; }


        protected ServiceBase(ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected ICommandExecutor CommandExecutor => Configuration.CommandExecutor;
    }
}