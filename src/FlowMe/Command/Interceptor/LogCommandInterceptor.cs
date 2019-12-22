using FlowMe.Engine.Logger;

namespace FlowMe.Command.Interceptor
{
    public class LogCommandInterceptor : CommandInterceptor
    {
        public override T Intercept<T>(ICommand<T> command, CommandConfig commandConfig)
        {
            LoggerHolder.Logger.Debug($"Start execute [{command.GetType().FullName}].");
            try
            {
                return Next.Intercept(command, commandConfig);
            }
            finally
            {
                LoggerHolder.Logger.Debug($"Finished [{command.GetType().FullName}].");
            }
        }
    }
}