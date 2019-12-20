using FlowMe.Model.Component.Event;

namespace FlowMe.Model
{
    public interface IBpmnModel
    {
        StartEvent GetEntry();
    }
}