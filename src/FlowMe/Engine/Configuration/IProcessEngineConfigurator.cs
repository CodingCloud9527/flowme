namespace FlowMe.Engine.Configuration
{
    public interface IProcessEngineConfigurator
    {
        int Priority { get; }

        void BeforeInit(ProcessEngineConfiguration configuration);

        void Configure(ProcessEngineConfiguration configuration);
    }
}