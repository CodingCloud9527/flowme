using FlowMe.Command.Context;

namespace FlowMe.Command
{
    public interface ICommand< out T>
    {
        T Execute(CommandContext commandContext);
    }
}