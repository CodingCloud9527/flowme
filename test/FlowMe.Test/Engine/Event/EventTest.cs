using FlowMe.Event.Dispatcher;
using Xunit;

namespace FlowMe.Test.Engine.Event
{
    public class EventTest : EngineTestBase
    {
        private class TestListener : IEventListener
        {
            public object Obj { get; set; }
            public string FocusOn => "Test";

            public void Listen(object data = null)
            {
                Obj = data;
            }
        }

        [Fact]
        public void ShouldPassDataWithEvent()
        {
            var eventDispatcher = ProcessEngine.CommonOp.EventDispatcher;
            var listener = new TestListener();
            const string eventName = "Test";
            eventDispatcher.AddListener(listener);
            var eventData = new object();
            eventDispatcher.DispatchEvent(eventName, eventData);
            Assert.True(listener.Obj == eventData);
            eventDispatcher.DispatchEvent(eventName);
            Assert.True(listener.Obj == null);
        }
    }
}