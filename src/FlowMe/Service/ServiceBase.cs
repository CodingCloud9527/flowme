using FlowMe.Engine.Configuration;

namespace FlowMe.Service
{
    public abstract class ServiceBase
    {
        protected ProcessEngineConfiguration _configuration;


        public ServiceBase(ProcessEngineConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}