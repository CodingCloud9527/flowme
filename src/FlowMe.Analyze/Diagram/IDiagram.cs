using FlowMe.Analyze.Model;
using FlowMe.Analyze.Model.Event;

namespace FlowMe.Analyze.Diagram
{
    /// <summary>
    ///     Describe the relation of components.
    /// </summary>
    public interface IDiagram
    {
        StartEvent GetEntry();
    }
}