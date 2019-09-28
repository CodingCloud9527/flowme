namespace BPMN.Analyze.Model
{
    internal abstract class FlowComponent
    {
        public string Id { get; protected set; }

        public string Name { get; protected set; }
    }
}