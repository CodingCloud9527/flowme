using FlowMe.Command.Interceptor;

namespace FlowMe.Command.Executor
{
    class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandInterceptor _first;
        public CommandConfig CommandConfig { get; }

        public CommandExecutor(CommandConfig commandConfig, ICommandInterceptor first)
        {
            CommandConfig = commandConfig;
            _first = first;
        }

        public T Execute<T>(ICommand<T> command)
        {
            return Execute(command, CommandConfig);
        }

        public T Execute<T>(ICommand<T> command, CommandConfig commandConfig)
        {
            return _first.Intercept(command, commandConfig);
        }
    }
}