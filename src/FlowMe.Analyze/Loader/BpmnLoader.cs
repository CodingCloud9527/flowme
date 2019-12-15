using FlowMe.Analyze.Diagram;

namespace FlowMe.Analyze.Loader
{
    public static class BpmnLoader
    {
        public static IDiagram Load(string bpmnContent)
        {
            return new Diagram.Diagram(bpmnContent);
        }
    }
}