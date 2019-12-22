using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowMe.Engine.Logger;
using log4net;

namespace FlowMe.Event.Dispatcher
{
    internal class EventDispatcher : IEventDispatcher
    {
        private readonly ISet<IEventListener> _customListeners;

        private readonly ILog _logger = LoggerHolder.Logger;
        private readonly ISet<IEventListener> _systemListeners;

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