using FlowMe.Command.Context;

namespace FlowMe.Command
{
    public interface ICommand<T>
    {
        T Execute(CommandContext<T> commandContext);
    }
}