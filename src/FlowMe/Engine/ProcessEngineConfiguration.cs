using System.Collections.Generic;
using FlowMe.Event.Bus;
using Microsoft.Extensions.Logging;

namespace FlowMe.Engine
{
    public class ProcessEngineConfiguration
    {
        ILogger Logger { get; set; }
        public IEventDispatcher EventDispatcher { get; internal set; }
        public IList<IEventListener> CustomEventListeners { get; set; }

        internal ProcessEngineConfiguration()
        {
        }
    }
}