using FlowMe.Model.Component.Event;

namespace FlowMe.Model.Process
{
    public interface IProcessModel
    {
        StartEvent GetEntry();
    }
}