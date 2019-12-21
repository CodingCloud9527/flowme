using FlowMe.Engine.Configuration;

namespace FlowMe.Command.Context
{
    public class CommandContextFactory
    {
        protected readonly ProcessEngineConfiguration Configuration;

        public CommandContextFactory(ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
        }

        public CommandContext<T> Create<T>(ICommand<T> command)
        {
            return new CommandContext<T>(command, Configuration);
        }
    }
}