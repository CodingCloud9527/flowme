using FlowMe.Engine.Configuration;
using FlowMe.Service;

namespace FlowMe.Engine
{
    public interface IProcessEngine
    {
        ITaskService TaskService { get; }
        IRuntimeService RuntimeService { get; }
        IHistoryService HistoryService { get; }
        IRepositoryService RepositoryService { get; }
        ProcessEngineConfiguration Configuration { get; }
    }
}