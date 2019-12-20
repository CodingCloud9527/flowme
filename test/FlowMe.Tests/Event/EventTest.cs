using FlowMe.Engine;
using FlowMe.Event.Bus;
using Xunit;
using Xunit.Abstractions;

namespace FlowMe.Tests.Event
{
    public class EventTest : EngineTestBase
    {
        [Fact]
        public void ShouldPassDataWithEvent()
        {
            var eventDispatcher = _processEngine.CommonOp.EventDispatcher;
            var listener = new TestListener();
            const string eventName = "Test";
            eventDispatcher.AddListener(listener);
            var eventData = new object();
            eventDispatcher.DispatchEvent(eventName, eventData);
            Assert.True(listener.Obj == eventData);
            eventDispatcher.DispatchEvent(eventName);
            Assert.True(listener.Obj == null);
        }

        class TestListener : IEventListener
        {
            public object Obj { get; set; }
            public string FocusOn => "Test";

            public void Listen(object data = null)
            {
                Obj = data;
            }
        }
    }
}