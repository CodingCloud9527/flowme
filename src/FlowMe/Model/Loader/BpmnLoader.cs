using FlowMe.Model.Process;

namespace FlowMe.Model.Loader
{
    public static class BpmnLoader
    {
        public static IProcessModel Load(string bpmnContent)
        {
            return new ProcessModel(bpmnContent);
        }
    }
}