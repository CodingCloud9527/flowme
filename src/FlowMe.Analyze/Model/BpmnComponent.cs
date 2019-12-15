using System.Xml;

namespace FlowMe.Analyze.Model
{
    /// <summary>
    /// indicate that is a workflow component
    /// </summary>
    public abstract class BpmnComponent
    {
        public string Id { get; protected set; }

        public string Name { get; protected set; }

        public virtual BpmnComponent ConvertFromXml(XmlElement ele)
        {
            Id = ele.GetAttribute("id");
            Name = ele.GetAttribute("name");
            return this;
        }
    }
}