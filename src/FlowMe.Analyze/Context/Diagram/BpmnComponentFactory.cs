using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using FlowMe.Analyze.Model;
using FlowMe.Analyze.Model.Event;
using FlowMe.Analyze.Model.Gateway;
using FlowMe.Analyze.Model.SequenceFlow;
using FlowMe.Analyze.Model.Task;

namespace FlowMe.Analyze.Context.Diagram
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
            if (!NodeMapping.ContainsKey(ele.Name))
            {
                throw new UnsupportedElementException(ele);
            }

            return ((BpmnComponent) Activator.CreateInstance(NodeMapping[ele.Name])).ConvertFromXmlNode(ele);
        }
    }

    public class UnsupportedElementException : Exception
    {
        public UnsupportedElementException(XmlNode node) : base($"the element [{node.Name}] not support yet!")
        {
        }
    }
}