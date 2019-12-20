namespace FlowMe.Event.Dispatcher
{
    public interface IEventListener
    {
        string FocusOn { get; }

        void Listen(object data = null);
    }
}