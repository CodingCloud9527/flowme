using System.Xml;

namespace FlowMe.Model.Component
{
    /// <summary>
    ///     indicate that is a workflow component
    /// </summary>
    public abstract class BpmnComponent
    {
        public string Id { get; protected set; }

        public string Name { get; protected set; }

        public XmlElement Stub { get; protected set; }

        public BpmnComponent ConvertFromXml(XmlElement ele)
        {
            Id = ele.GetAttribute("id");
            Name = ele.GetAttribute("name");
            Stub = ele;
            Convert(ele);
            return this;
        }

        protected virtual void Convert(XmlElement ele)
        {
        }
    }
}