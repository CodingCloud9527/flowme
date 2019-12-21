namespace FlowMe.Command.Interceptor
{
    public interface ICommandInterceptor
    {
        T Intercept<T>(ICommand<T> command, CommandConfig commandConfig);

        ICommandInterceptor Next { get; set; }
    }
}