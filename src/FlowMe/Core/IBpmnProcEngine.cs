namespace FlowMe.Core
{
    public interface IBpmnProcEngine
    {
        IProcDefService ProcDefService { get; }
        
        IProcInstService ProcInstService { get; }
        
        IProcTaskService ProcTaskService { get; }
    }
}