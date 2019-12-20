using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowMe.Engine.Logger;
using Microsoft.Extensions.Logging;

namespace FlowMe.Event.Bus
{
    class EventPublisher : IEventPublisher
    {
        private readonly ISet<IEventListener> _customListeners;
        private readonly ISet<IEventListener> _systemListeners;

        private ILogger _logger = LoggerHolder.Logger;

        internal EventPublisher()
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

        public void Publish(string eventName)
        {
            Parallel.ForEach(_systemListeners.Where(e => e.FocusOn == eventName),
                listener =>
                {
                    try
                    {
                        listener.Listen();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message);
                    }
                });

            Parallel.ForEach(_customListeners.Where(e => e.FocusOn == eventName),
                listener =>
                {
                    try
                    {
                        listener.Listen();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message);
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