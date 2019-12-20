using System;
using System.Collections.Generic;
using System.Xml;
using FlowMe.Model.Component;
using FlowMe.Model.Component.Event;
using FlowMe.Model.Component.Gateway;
using FlowMe.Model.Component.Task;

namespace FlowMe.Model
{
    public static class BpmnComponentFactory
    {
        private static readonly IReadOnlyDictionary<string, Type> NodeMapping = new Dictionary<string, Type>
        {
            #region sequenceFlow

            {"sequenceFlow", typeof(SequenceFlow)},

            #endregion

            #region event

            {"startEvent", typeof(NullStartEvent)},
            {"endEvent", typeof(NullEndEvent)},

            #endregion

            #region gateway

            {"exclusiveGateway", typeof(ExclusiveGateway)},
            {"parallelGateway", typeof(ParallelGateway)},
            {"inclusiveGateway", typeof(InclusiveGateway)},

            #endregion

            #region task

            {"userTask", typeof(UserTask)}

            #endregion
        };

        public static BpmnComponent Create(XmlElement ele)
        {
            if (!NodeMapping.ContainsKey(ele.LocalName)) throw new UnsupportedElementException(ele);

            return ((BpmnComponent) Activator.CreateInstance(NodeMapping[ele.LocalName])).ConvertFromXml(ele);
        }
    }

    public class UnsupportedElementException : Exception
    {
        public UnsupportedElementException(XmlNode node) : base($"the element [{node.Name}] does not support yet!")
        {
        }
    }
}