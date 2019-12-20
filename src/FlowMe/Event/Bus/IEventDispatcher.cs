using System;

namespace FlowMe.Event.Bus
{
    public interface IEventDispatcher
    {
        void AddListener(IEventListener eventListener);

        void RemoveListener(IEventListener eventListener);

        
        void DispatchEvent(string eventName, object data = null);
    }
}