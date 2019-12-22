using FlowMe.Command.Context;
using FlowMe.Engine.Configuration;

namespace FlowMe.Command.Interceptor
{
    public class CommandContextInterceptor : CommandInterceptor
    {
        private readonly CommandContextFactory _commandContextFactory;
        private readonly ProcessEngineConfiguration _configuration;


        public CommandContextInterceptor(CommandContextFactory commandContextFactory, ProcessEngineConfiguration configuration)
        {
            _commandContextFactory = commandContextFactory;
            _configuration = configuration;
        }

        public override T Intercept<T>(ICommand<T> command, CommandConfig commandConfig)
        {
            var commandContext = ContextRecorder.CommandContext;
            commandContext ??= _commandContextFactory.Create(command);

            try
            {
                ContextRecorder.CommandContext = commandContext;
                ContextRecorder.Configuration = _configuration;
                return Next.Intercept(command, commandConfig);
            }
            finally
            {
                ContextRecorder.PopCommandContext();
                ContextRecorder.PopConfiguration();
            }
        }
    }
}