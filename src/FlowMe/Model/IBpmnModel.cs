using FlowMe.Model.Component;
using FlowMe.Model.Component.Event;

namespace FlowMe.Model
{
    public interface IBpmnModel
    {
        StartEvent Entry { get; }
        string Name { get; }
        string Id { get; }
        BpmnComponent GetComponentById(string id);
        
    }
}