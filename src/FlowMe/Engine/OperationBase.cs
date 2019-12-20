namespace FlowMe.Engine
{
    public abstract class OperationBase
    {
        protected ProcessEngineConfiguration _configuration;


        public OperationBase(ProcessEngineConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}