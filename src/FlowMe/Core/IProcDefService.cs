using FlowMe.Analyze.Process;

namespace FlowMe.Core
{
    public interface IProcDefService
    {
        void Deploy(IProcessDiagram diagram);

        bool TryUnDeploy(string name);
    }
}