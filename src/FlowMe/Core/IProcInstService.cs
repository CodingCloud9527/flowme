namespace FlowMe.Core
{
    public interface IProcInstService
    {
        string StartByName(string name);

        void AddProcVar(string procInstId, string varName, object varValue);

        bool IsComplete(string procInstId);
    }
}