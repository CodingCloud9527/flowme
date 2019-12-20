using System.Collections.Generic;
using FlowMe.Event.Dispatcher;
using Microsoft.Extensions.Logging;

namespace FlowMe.Engine
{
    public class ProcessEngineConfiguration
    {
        internal ProcessEngineConfiguration()
        {
        }

        private ILogger Logger { get; set; }
        public IEventDispatcher EventDispatcher { get; internal set; }
        public IList<IEventListener> CustomEventListeners { get; set; }
    }
}