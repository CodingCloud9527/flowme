using FlowMe.Core.Task;

namespace FlowMe.Core
{
    public interface IProcTaskService
    {
        ITaskQueryable CreateTaskQuery();
    }
}