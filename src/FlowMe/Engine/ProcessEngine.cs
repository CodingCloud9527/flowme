using FlowMe.Engine.Configuration;
using FlowMe.Service;

namespace FlowMe.Engine
{
    public class ProcessEngine : IProcessEngine
    {
        public ProcessEngineConfiguration Configuration { get; }


        public ProcessEngine(ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ITaskService TaskService { get; }
        public IRuntimeService RuntimeService { get; }
        public IHistoryService HistoryService { get; }
        public IRepositoryService RepositoryService => Configuration.RepositoryService;
    }
}