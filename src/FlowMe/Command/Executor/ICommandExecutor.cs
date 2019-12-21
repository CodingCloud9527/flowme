namespace FlowMe.Command.Executor
{
    public interface ICommandExecutor
    {
        CommandConfig CommandConfig { get; }

        T Execute<T>(ICommand<T> command);

        T Execute<T>(ICommand<T> command, CommandConfig commandConfig);
    }
}