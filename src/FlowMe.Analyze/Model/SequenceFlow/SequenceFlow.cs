namespace FlowMe.Analyze.Model.SequenceFlow
{
    internal class SequenceFlow : BpmnComponent
    {
        public BpmnNodeComponent SourceRef { get; set; }
        public BpmnNodeComponent TargetRef { get; set; }
        public string ConditionExpression { get; set; }
    }
}