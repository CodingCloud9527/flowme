using FlowMe.Command.Context;

namespace FlowMe.Command.Interceptor
{
    public class EfCoreTransactionInterceptor : CommandInterceptor
    {
        public override T Intercept<T>(ICommand<T> command, CommandConfig commandConfig)
        {
            var dbContext = ContextRecorder.Configuration.DbContext;
            var transaction = dbContext.Database.BeginTransaction();
            var commandContext = ContextRecorder.CommandContext;
            try
            {
                return Next.Intercept(command, commandConfig);
            }
            finally
            {
                if (commandContext.CommandException == null)
                {
                    dbContext.SaveChanges();
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