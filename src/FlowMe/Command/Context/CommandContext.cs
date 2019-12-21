using FlowMe.Engine.Configuration;

namespace FlowMe.Command.Context
{
    public class CommandContext<T>
    {
        public CommandContext(ICommand<T> command, ProcessEngineConfiguration configuration)
        {
            
        }
    }
}