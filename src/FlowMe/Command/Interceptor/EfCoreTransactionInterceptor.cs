using FlowMe.Command.Context;

namespace FlowMe.Command.Interceptor
{
    public class EfCoreTransactionInterceptor : CommandInterceptor
    {
        public override T Intercept<T>(ICommand<T> command, CommandConfig commandConfig)
        {
            var transaction = ContextRecorder.Configuration.DbContext.Database.BeginTransaction();
            var commandContext = ContextRecorder.CommandContext;
            try
            {
                return Next.Intercept(command, commandConfig);
            }
            finally
            {
                if (commandContext.CommandException == null)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
            }
        }
    }
}