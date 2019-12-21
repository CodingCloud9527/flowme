using System;
using FlowMe.Command;
using FlowMe.Command.Context;
using FlowMe.Command.Interceptor.Invoker;
using FlowMe.Engine.Configuration;
using FlowMe.Event.Dispatcher;
using FlowMe.Persistence;

namespace FlowMe.Engine
{
    public class ProcessEngineFactory
    {
        private static IProcessEngine _cache;

        private static readonly Lazy<ProcessEngineFactory> _ =
            new Lazy<ProcessEngineFactory>(() => new ProcessEngineFactory());

        private ProcessEngineConfiguration _configuration;

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
            InitCommandContextFactory();
            InitCommandExecutors();
            InitDbContext();
        }


        private void InitDbContext()
        {
            _configuration.DbContext = new BpmnDbContext();
        }

        private void InitEventDispatcher()
        {
            _configuration.EventDispatcher = new EventDispatcher();
            if (_configuration.CustomEventListeners != null)
                foreach (var customEventListener in _configuration.CustomEventListeners)
                    _configuration.EventDispatcher.AddListener(customEventListener);
        }

        private void InitCommandExecutors()
        {
            InitDefaultCommandConfig();
        }

        private void InitCommandContextFactory()
        {
            _configuration.CommandContextFactory ??= new CommandContextFactory(_configuration);
        }

        #region Init command executors

        private void InitDefaultCommandConfig()
        {
            _configuration.CommandConfig ??= new CommandConfig();
        }

        private void InitDefaultCommandInvoker()
        {
            _configuration.CommandInvoker ??= new CommandInvoker();
        }
        
        #endregion
     
    }
}