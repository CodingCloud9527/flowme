using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using FlowMe.Command;
using FlowMe.Command.Context;
using FlowMe.Command.Executor;
using FlowMe.Command.Interceptor;
using FlowMe.Command.Interceptor.Invoker;
using FlowMe.Engine.Configuration;
using FlowMe.Event.Dispatcher;
using FlowMe.Persistence;
using FlowMe.Service.Repository;

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
            InitCommandChainSetting();
            InitDbContext();
            InitService();
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

        private void InitCommandChainSetting()
        {
            InitDefaultCommandConfig();
            InitDefaultCommandInvoker();
            InitCommandInterceptors();
            InitCommandExecutor();
        }

        private void InitCommandContextFactory()
        {
            _configuration.CommandContextFactory ??= new CommandContextFactory(_configuration);
        }

        private void InitService()
        {
            _configuration.RepositoryService ??= new RepositoryService(_configuration);
        }

        #region Init command setting

        private void InitDefaultCommandConfig()
        {
            _configuration.CommandConfig ??= new CommandConfig();
        }

        private void InitDefaultCommandInvoker()
        {
            _configuration.CommandInvoker ??= new CommandInvoker();
        }

        private void InitCommandInterceptors()
        {
            _configuration.CommandInterceptors ??= new List<ICommandInterceptor>();
            if (!_configuration.CustomPreInterceptors.IsNullOrEmpty())
            {
                _configuration.CommandInterceptors.AddRange(_configuration.CustomPreInterceptors);
            }

            _configuration.CommandInterceptors.AddRange(DefaultInterceptors());

            if (!_configuration.CustomPostInterceptors.IsNullOrEmpty())
            {
                _configuration.CommandInterceptors.AddRange(_configuration.CustomPostInterceptors);
            }

            _configuration.CommandInterceptors.Add(_configuration.CommandInvoker);
        }

        private void InitCommandExecutor()
        {
            if (_configuration.CommandExecutor == null)
            {
                var chain = _configuration.CommandInterceptors;
                if (chain.IsNullOrEmpty())
                {
                    throw new Exception("Command interceptor chain can not be null!");
                }

                for (var i = 0; i < chain.Count - 1; i++)
                {
                    chain[i].Next = chain[i + 1];
                }

                _configuration.CommandExecutor = new CommandExecutor(_configuration.CommandConfig, chain[0]);
            }
        }

        private List<ICommandInterceptor> DefaultInterceptors()
        {
            var defaultInterceptors = new List<ICommandInterceptor>
            {
                new LogCommandInterceptor(),
                new CommandContextInterceptor(_configuration.CommandContextFactory, _configuration),
                new EfCoreTransactionInterceptor()
            };
            return defaultInterceptors;
        }

        #endregion
    }
}