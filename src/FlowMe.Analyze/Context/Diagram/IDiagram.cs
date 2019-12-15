using FlowMe.Analyze.Model;

namespace FlowMe.Analyze.Context.Diagram
{
    /// <summary>
    /// Describe the relation of components.
    /// </summary>
    internal interface IDiagram
    {
        /// <summary>
        /// Attach a component to current flow diagram. 
        /// </summary>
        /// <param name="component">the component you want to attach</param>
        void Attach(BpmnComponent component);

        /// <summary>
        /// Detach a component to current flow diagram.
        /// </summary>
        /// <param name="component">the component you want to detach</param>
        void Detach(BpmnComponent component);

        /// <summary>
        /// Detach a component by the id.
        /// </summary>
        /// <param name="id">component's id which you want to detach</param>
        void Detach(string id);
    }
}