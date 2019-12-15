using System.Collections.Generic;

namespace FlowMe.Analyze.Model
{
    /// <summary>
    ///     Node component doesn't include <see cref="SequenceFlow" />
    /// </summary>
    public abstract class BpmnNodeComponent : BpmnComponent
    {
        public virtual List<SequenceFlow> SourceRef { get; set; }
        public virtual List<SequenceFlow> TargetRef { get; set; }
    }
}