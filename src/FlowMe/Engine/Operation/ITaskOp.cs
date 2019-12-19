using FlowMe.Engine.Task;

namespace FlowMe.Engine.Operation
{
    public interface ITaskOp
    {
        ITaskQueryable CreateTaskQuery();
        
    }
}