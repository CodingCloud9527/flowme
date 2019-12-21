namespace FlowMe.Command.Interceptor
{
    public interface ICommandInterceptor
    {
        ICommandInterceptor Next { get; set; }
        T Intercept<T>(ICommand<T> command, CommandConfig commandConfig);
    }
}