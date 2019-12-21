using FlowMe.Engine.Configuration;
using FlowMe.Service;
using FlowMe.Service.Repository;

namespace FlowMe.Engine
{
    public class ProcessEngine : IProcessEngine
    {
        public ProcessEngine(ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ITaskService TaskService { get; }
        public IRuntimeService RuntimeService { get; }
        public IHistoryService HistoryService { get; }
        public IRepositoryService RepositoryService => new RepositoryService();
        public ProcessEngineConfiguration Configuration { get; }
    }
}