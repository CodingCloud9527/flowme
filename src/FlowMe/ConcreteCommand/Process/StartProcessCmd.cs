using FlowMe.Command;
using FlowMe.Command.Context;
using FlowMe.Persistence.Entity;

namespace FlowMe.ConcreteCommand.Process
{
    public class StartProcessCmd : ICommand<ProcessInstance>
    {
        public ProcessInstance Execute(CommandContext commandContext)
        {
            return null;
        }
    }
}