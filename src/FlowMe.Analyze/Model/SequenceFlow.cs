using System.Xml;

namespace FlowMe.Analyze.Model
{
    public class SequenceFlow : BpmnComponent
    {
        public BpmnNodeComponent SourceRef { get; set; }
        public BpmnNodeComponent TargetRef { get; set; }
        public string ConditionExpression { get; protected set; }


        protected override void Convert(XmlElement ele)
        {
            ConditionExpression = ele.SelectSingleNode("conditionExpression")?.InnerText;
        }
    }
}