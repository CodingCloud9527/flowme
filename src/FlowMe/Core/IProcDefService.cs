using FlowMe.Analyze.Diagram;

namespace FlowMe.Core
{
    public interface IProcDefService
    {
        void Deploy(IDiagram diagram);

        bool TryUnDeploy(string name);
    }
}