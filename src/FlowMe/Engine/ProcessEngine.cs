using FlowMe.Engine.Configuration;
using FlowMe.Service;
using FlowMe.Service.Repository;

namespace FlowMe.Engine
{
    public class ProcessEngine : IProcessEngine
    {
        private readonly ProcessEngineConfiguration _configuration;

        public ProcessEngine(ProcessEngineConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ITaskService TaskService { get; }
        public IRuntimeService RuntimeService { get; }
        public IHistoryService HistoryService { get; }
        public IRepositoryService RepositoryService => new RepositoryService(_configuration);
        public ProcessEngineConfiguration Configuration => _configuration;
    }
}