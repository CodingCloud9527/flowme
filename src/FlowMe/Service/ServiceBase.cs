using FlowMe.Engine.Configuration;

namespace FlowMe.Service
{
    public abstract class ServiceBase
    {
        public ProcessEngineConfiguration Configuration { get; set; }


        public ServiceBase()
        {
        }

        public ServiceBase(ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}