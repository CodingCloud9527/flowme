namespace FlowMe.Event.Dispatcher
{
    public interface IEventDispatcher
    {
        void AddListener(IEventListener eventListener);

        void RemoveListener(IEventListener eventListener);


        void DispatchEvent(string eventName, object data = null);
    }
}