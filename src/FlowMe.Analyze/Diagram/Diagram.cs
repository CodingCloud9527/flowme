using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FlowMe.Analyze.Model;
using FlowMe.Analyze.Model.Event;

namespace FlowMe.Analyze.Diagram
{
    internal class Diagram : IDiagram
    {
        private const string ProcessDefXPath = "/definitions/process";
        private readonly HashSet<BpmnComponent> _resolved = new HashSet<BpmnComponent>();
        private readonly HashSet<BpmnComponent> _unResolved = new HashSet<BpmnComponent>();

        private StartEvent _startEvent;

        public Diagram(string bpmnContent)
        {
            Translate(bpmnContent);
            CheckComponents();
            Assemble();
        }


        public StartEvent GetEntry()
        {
            return _startEvent;
        }


        private void Assemble()
        {
            _startEvent = (StartEvent) _unResolved.Single(e => e is StartEvent);
            var endEventCntBeforeAssemble = _unResolved.Count(e => e is EndEvent);

            var sequenceFlows = _unResolved.OfType<SequenceFlow>().ToHashSet();
            var bpmnNodes = _unResolved.OfType<BpmnNodeComponent>().ToHashSet();
            foreach (var sequenceFlow in sequenceFlows)
            {
                var head = bpmnNodes.SingleOrDefault(e => e.Stub.Id() == sequenceFlow.Stub.SourceRefId());
                if (head != null)
                {
                    head.TargetRef.Add(sequenceFlow);
                    sequenceFlow.SourceRef = head;
                    _unResolved.Remove(head);
                }

                var tail = bpmnNodes.SingleOrDefault(e => e.Stub.Id() == sequenceFlow.Stub.TargetRefId());
                if (tail != null)
                {
                    tail.SourceRef.Add(sequenceFlow);
                    sequenceFlow.TargetRef = tail;
                    _unResolved.Remove(tail);
                }

                if (head != null || tail != null)
                {
                    _unResolved.Remove(sequenceFlow);
                }
            }

            var endEventCntAfterAssemble = _unResolved.Count(e => e is EndEvent);

            if (_unResolved.Contains(_startEvent) || endEventCntAfterAssemble == endEventCntBeforeAssemble)
            {
                throw new Exception(
                    "An error occurred while constructing flow diagram. Make sure that the flow diagram contains start event and end event!");
            }
        }

        private void CheckComponents()
        {
            //id can't duplicate
            if (_unResolved.GroupBy(e => e.Id).Select(e => e.Count()).Any(e => e > 1))
            {
                throw new Exception("Bpmn component's id can't duplicate!");
            }

            //Must contain exactly one start event
            if (_unResolved.Count(e => e is StartEvent) != 1)
            {
                throw new Exception("Must contain exactly one start event!");
            }

            //Must contain at least one end event
            if (!_unResolved.Any(e => e is EndEvent))
            {
                throw new Exception("Must contain at least one end event!");
            }
        }

        private void Translate(string bpmnContent)
        {
            var bpmnXml = new XmlDocument();
            bpmnXml.LoadXml(bpmnContent);
            var processNode = bpmnXml.SelectSingleNode(ProcessDefXPath);
            if (processNode == null || !processNode.HasChildNodes)
            {
                throw new Exception("the bpmn content is invalid!");
            }

            foreach (XmlElement ele in processNode)
            {
                _unResolved.Add(BpmnComponentFactory.Create(ele));
            }
        }
    }
}