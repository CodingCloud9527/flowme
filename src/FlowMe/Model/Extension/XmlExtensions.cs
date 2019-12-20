using System.Xml;

namespace FlowMe.Model.Extension
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