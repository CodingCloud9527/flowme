using System;
using FlowMe.Command.Context;

namespace FlowMe.Command.Interceptor.Invoker
{
    public class CommandInvoker : ICommandInterceptor
    {
        public virtual T Intercept<T>(ICommand<T> command, CommandConfig commandConfig)
        {
            var commandContext = ContextRecorder.CommandContext;
            return command.Execute(commandContext);
        }

        public ICommandInterceptor Next
        {
            get => null;
            set => throw new InvalidOperationException("Command invoker must be the last interceptor of interceptor chain");
        }
    }
}