using FlowMe.Analyze.Process;

namespace FlowMe.Analyze.Loader
{
    public static class BpmnLoader
    {
        public static IProcessModel Load(string bpmnContent)
        {
            return new ProcessModel(bpmnContent);
        }
    }
}