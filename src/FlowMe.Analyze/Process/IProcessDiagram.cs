using FlowMe.Analyze.Model.Event;

namespace FlowMe.Analyze.Process
{
    public interface IProcessDiagram
    {
        StartEvent GetEntry();
    }
}