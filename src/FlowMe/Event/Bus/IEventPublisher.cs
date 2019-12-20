using System;

namespace FlowMe.Event.Bus
{
    public interface IEventPublisher
    {
        void AddListener(IEventListener eventListener);

        void RemoveListener(IEventListener eventListener);

        void Publish(string eventName);
    }
}