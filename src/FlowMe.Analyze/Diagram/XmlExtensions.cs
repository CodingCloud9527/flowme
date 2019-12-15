using System.Xml;

namespace FlowMe.Analyze.Diagram
{
    public static class XmlExtensions
    {
        public static string Id(this XmlElement ele)
        {
            return ele.GetAttribute("id");
        }

        public static string SourceRefId(this XmlElement ele)
        {
            return ele.GetAttribute("sourceRef");
        }

        public static string TargetRefId(this XmlElement ele)
        {
            return ele.GetAttribute("targetRef");
        }
    }
}