using FlowMe.Model.Loader;

namespace FlowMe.Model.Validate
{
    class BpmnValidator : IBpmnValidator
    {
        public bool Validate(string bpmnContent)
        {
            var bpmnModel = BpmnLoader.Load(bpmnContent);
            //TODO: validate bpmn model
            return true;
        }
    }
}