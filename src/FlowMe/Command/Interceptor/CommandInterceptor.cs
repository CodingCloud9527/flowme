namespace FlowMe.Command.Interceptor
{
    public abstract class CommandInterceptor : ICommandInterceptor
    {
        public ICommandInterceptor Next { get; set; }
        public abstract T Intercept<T>(ICommand<T> command, CommandConfig commandConfig);
    }
}