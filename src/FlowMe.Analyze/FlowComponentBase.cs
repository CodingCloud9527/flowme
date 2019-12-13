﻿namespace FlowMe.Analyze
{
    internal abstract class FlowComponentBase : IFlowComponent
    {
        public string Id { get; protected set; }

        public string Name { get; protected set; }
    }
}