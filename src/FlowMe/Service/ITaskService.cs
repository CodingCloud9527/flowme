using FlowMe.Engine.Task;

namespace FlowMe.Service
{
    public interface ITaskService
    {
        ITaskQueryable CreateTaskQuery();
    }
}