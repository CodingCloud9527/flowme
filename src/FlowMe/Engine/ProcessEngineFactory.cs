namespace FlowMe.Engine
{
    public static class ProcessEngineFactory
    {
        private static ProcessEngineConfiguration _configuration;

        public static IProcessEngine Create(ProcessEngineConfiguration configuration = null)
        {
            _configuration = configuration ?? ProcessEngineConfiguration.Default;
        }
    }
}