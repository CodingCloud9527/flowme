using System.Collections.Generic;
using Castle.Core.Logging;
using FlowMe.Engine.Logger;
using FlowMe.Event.Dispatcher;

namespace FlowMe.Engine
{
    public class ProcessEngineConfiguration
    {
        internal ProcessEngineConfiguration()
        {
        }

        private ILogger Logger
        {
            set => LoggerHolder.Logger = value;
            get => LoggerHolder.Logger;
        }

        public IEventDispatcher EventDispatcher { get; internal set; }
        public IList<IEventListener> CustomEventListeners { get; set; }
    }
}