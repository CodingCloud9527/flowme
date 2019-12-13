

using FlowMe.Analyze.Context;

namespace FlowMe.Analyze.Loader
{
    public interface IBpmnLoader
    {
        IBpmnContext Load(string bpmnContent);
    }
}