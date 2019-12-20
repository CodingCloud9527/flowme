using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FlowMe.Model.Component;
using FlowMe.Model.Component.Event;
using FlowMe.Model.Const;
using FlowMe.Model.Extension;

namespace FlowMe.Model
{
    internal class BpmnModel : IBpmnModel
    {
        private readonly HashSet<BpmnComponent> _unResolved = new HashSet<BpmnComponent>();
        private readonly Dictionary<string, BpmnComponent> _components = new Dictionary<string, BpmnComponent>();

        private StartEvent _startEvent;

        public BpmnModel(string bpmnContent)
        {
            Translate(bpmnContent);
            CheckComponents();
            Assemble();
            //TODO: handle if some components unresolved
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
                    ResolveItem(head);
                }

                var tail = bpmnNodes.SingleOrDefault(e => e.Stub.Id() == sequenceFlow.Stub.TargetRefId());
                if (tail != null)
                {
                    tail.SourceRef.Add(sequenceFlow);
                    sequenceFlow.TargetRef = tail;
                    ResolveItem(tail);
                }

                if (head != null || tail != null) ResolveItem(sequenceFlow);
            }

            var endEventCntAfterAssemble = _unResolved.Count(e => e is EndEvent);

            if (_unResolved.Contains(_startEvent) || endEventCntAfterAssemble == endEventCntBeforeAssemble)
                throw new Exception(
                    "An error occurred while constructing flow diagram. Make sure that the flow diagram contains start event and end event!");
        }


        private void CheckComponents()
        {
            //id can't duplicate
            if (_unResolved.GroupBy(e => e.Id).Select(e => e.Count()).Any(e => e > 1))
                throw new Exception("Bpmn component's id can't duplicate!");

            //Must contain exactly one start event
            if (_unResolved.Count(e => e is StartEvent) != 1)
                throw new Exception("Must contain exactly one start event!");

            //Must contain at least one end event
            if (!_unResolved.Any(e => e is EndEvent)) throw new Exception("Must contain at least one end event!");
        }

        private void Translate(string bpmnContent)
        {
            var bpmnXml = new XmlDocument();
            bpmnXml.LoadXml(bpmnContent);
            var bpmnXmlElement = bpmnXml.DocumentElement;
            if (bpmnXmlElement == null) throw new Exception("The Xml doesn't contain any element!");

            var bpmnPrefix = bpmnXmlElement.GetPrefixOfNamespace(BpmnXmlConst.BPMN2_NAMESPACE);
            var procDefTag = bpmnXmlElement.GetElementsByTagName($"{bpmnPrefix}:{BpmnXmlConst.ELEMENT_PROCESS}");

            if (procDefTag == null || procDefTag.Count < 1 || !procDefTag[0].HasChildNodes)
                throw new Exception("Not a valid Bpmn content!");

            Id = ((XmlElement) procDefTag[0]).GetAttribute("id");
            Name = ((XmlElement) procDefTag[0]).GetAttribute("name");

            foreach (XmlElement ele in procDefTag[0].ChildNodes) _unResolved.Add(BpmnComponentFactory.Create(ele));
        }

        private void ResolveItem(BpmnComponent component)
        {
            _unResolved.Remove(component);
            _components[component.Id] = component;
        }

        public StartEvent Entry => _startEvent;

        public string Name { get; private set; }

        public string Id { get; private set; }

        public BpmnComponent GetComponentById(string id)
        {
            return _components[id];
        }
    }
}