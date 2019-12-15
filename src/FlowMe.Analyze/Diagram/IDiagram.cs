using FlowMe.Analyze.Model;
using FlowMe.Analyze.Model.Event;

namespace FlowMe.Analyze.Diagram
{
    public interface IDiagram
    {
        StartEvent GetEntry();
    }
}