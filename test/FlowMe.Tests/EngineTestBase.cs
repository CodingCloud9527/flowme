using FlowMe.Engine;

namespace FlowMe.Tests
{
    public abstract class EngineTestBase
    {
        protected IProcessEngine _processEngine;

        protected EngineTestBase()
        {
            _processEngine = ProcessEngineFactory.Instance.Create();
           
        }
    }
}