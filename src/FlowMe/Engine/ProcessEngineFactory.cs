using System;
using FlowMe.Event.Bus;

namespace FlowMe.Engine
{
    public class ProcessEngineFactory
    {
        private ProcessEngineConfiguration _configuration;

        private static IProcessEngine _cache;

        private static readonly Lazy<ProcessEngineFactory> _ =
            new Lazy<ProcessEngineFactory>(() => new ProcessEngineFactory());

        private ProcessEngineFactory()
        {
        }

        public static ProcessEngineFactory Instance => _.Value;


        public IProcessEngine Create(ProcessEngineConfiguration configuration = null)
        {
            if (_cache == null)
            {
                _configuration = configuration ?? new ProcessEngineConfiguration();
                Init();
                _cache = new ProcessEngine(_configuration);
            }

            return _cache;
        }

        private void Init()
        {
            InitEventDispatcher();
        }

        private void InitEventDispatcher()
        {
            _configuration.EventDispatcher = new EventDispatcher();
            if (_configuration.CustomEventListeners != null)
            {
                foreach (var customEventListener in _configuration.CustomEventListeners)
                {
                    _configuration.EventDispatcher.AddListener(customEventListener);
                }
            }
        }
    }
}