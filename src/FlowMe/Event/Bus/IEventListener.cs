namespace FlowMe.Event.Bus
{
    public interface IEventListener
    {
        string FocusOn { get; }

        void Listen(object data = null);
    }
}