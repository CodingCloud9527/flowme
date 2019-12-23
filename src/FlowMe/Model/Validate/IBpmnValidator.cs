namespace FlowMe.Model.Validate
{
    public interface IBpmnValidator
    {
        bool Validate(string bpmnContent);
    }
}