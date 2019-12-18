using FlowMe.Analyze.Process;

namespace FlowMe.Analyze.Loader
{
    public static class BpmnLoader
    {
        public static IProcessDiagram Load(string bpmnContent)
        {
            return new ProcessDiagram(bpmnContent);
        }
    }
}