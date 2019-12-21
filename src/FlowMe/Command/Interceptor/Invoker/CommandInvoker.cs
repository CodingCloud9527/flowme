using FlowMe.Command.Context;

namespace FlowMe.Command.Interceptor.Invoker
{
    public class CommandInvoker : ICommandInterceptor
    {
        public T Intercept<T>(ICommand<T> command, CommandConfig commandConfig)
        {
            var commandContext = ContextRecorder.CommandContext;
            return command.Execute(commandContext);
        }

        public ICommandInterceptor Next { get; set; }
    }
}