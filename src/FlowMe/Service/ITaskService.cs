using FlowMe.Task;

namespace FlowMe.Service
{
    public interface ITaskService
    {
        ITaskQueryable CreateTaskQuery();
    }
}