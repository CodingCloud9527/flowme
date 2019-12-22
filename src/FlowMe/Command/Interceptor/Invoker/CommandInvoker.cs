using System;
using FlowMe.Command.Context;
using FlowMe.Engine.Logger;

namespace FlowMe.Command.Interceptor.Invoker
{
    public class CommandInvoker : ICommandInterceptor
    {
        public virtual T Intercept<T>(ICommand<T> command, CommandConfig commandConfig)
        {
            var commandContext = ContextRecorder.CommandContext;
            try
            {
                return command.Execute(commandContext);
            }
            catch (Exception e)
            {
                commandContext.CommandException = e;
                LoggerHolder.Logger.Error($"An error occuring while executing [{command.GetType().FullName}], reason: {e.Message}");
                return default;
            }
        }

        public ICommandInterceptor Next
        {
            get => null;
            set => throw new InvalidOperationException("Command invoker must be the last interceptor of interceptor chain");
        }
    }
}