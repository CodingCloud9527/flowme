using FlowMe.Command.Interceptor;

namespace FlowMe.Command.Executor
{
    internal class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandInterceptor _first;

        public CommandExecutor(CommandConfig commandConfig, ICommandInterceptor first)
        {
            CommandConfig = commandConfig;
            _first = first;
        }

        public CommandConfig CommandConfig { get; }

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