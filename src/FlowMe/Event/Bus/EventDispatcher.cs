using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using FlowMe.Engine.Logger;

namespace FlowMe.Event.Bus
{
    class EventDispatcher : IEventDispatcher
    {
        private readonly ISet<IEventListener> _customListeners;
        private readonly ISet<IEventListener> _systemListeners;

        private ILogger _logger = LoggerHolder.Logger;

        internal EventDispatcher()
        {
            _systemListeners = new HashSet<IEventListener>();
            _customListeners = new HashSet<IEventListener>();
        }


        public void AddListener(IEventListener eventListener)
        {
            _customListeners.Add(eventListener);
        }

        public void RemoveListener(IEventListener eventListener)
        {
            _customListeners.Remove(eventListener);
        }

        public void DispatchEvent(string eventName, object data = null)
        {
            Parallel.ForEach(_systemListeners.Where(e => e.FocusOn == eventName),
                listener =>
                {
                    try
                    {
                        listener.Listen(data);
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e.Message);
                    }
                });

            Parallel.ForEach(_customListeners.Where(e => e.FocusOn == eventName),
                listener =>
                {
                    try
                    {
                        listener.Listen(data);
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e.Message);
                    }
                });
        }


        internal void AddSystemListener(IEventListener systemEventListener)
        {
            _systemListeners.Add(systemEventListener);
        }

        internal void RemoveSystemListener(IEventListener systemEventListener)
        {
            _systemListeners.Remove(systemEventListener);
        }
    }
}