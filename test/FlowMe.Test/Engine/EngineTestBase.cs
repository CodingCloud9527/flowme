using FlowMe.Engine;

namespace FlowMe.Test.Engine
{
    public abstract class EngineTestBase
    {
        protected readonly IProcessEngine ProcessEngine;

        protected EngineTestBase()
        {
            ProcessEngine = ProcessEngineFactory.Instance.Create();
        }
    }
}