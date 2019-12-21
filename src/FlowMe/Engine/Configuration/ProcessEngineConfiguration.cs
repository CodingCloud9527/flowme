using System.Collections.Generic;
using Castle.Core.Logging;
using FlowMe.Command;
using FlowMe.Command.Context;
using FlowMe.Command.Executor;
using FlowMe.Command.Interceptor;
using FlowMe.Engine.Logger;
using FlowMe.Event.Dispatcher;
using FlowMe.Persistence;
using FlowMe.Service;

namespace FlowMe.Engine.Configuration
{
    public class ProcessEngineConfiguration
    {
        private ILogger Logger
        {
            set => LoggerHolder.Logger = value;
            get => LoggerHolder.Logger;
        }

        public IEventDispatcher EventDispatcher { get; internal set; }

        internal BpmnDbContext DbContext { get; set; }
        internal IList<IEventListener> CustomEventListeners { get; set; }
        internal CommandContextFactory CommandContextFactory { get; set; }
        internal CommandConfig CommandConfig { get; set; }
        internal ICommandInterceptor CommandInvoker { get; set; }

        internal ICommandExecutor CommandExecutor { get; set; }

        internal List<ICommandInterceptor> CustomPreInterceptors { get; set; }
        internal List<ICommandInterceptor> CustomPostInterceptors { get; set; }
        internal List<ICommandInterceptor> CommandInterceptors { get; set; }

        internal IRepositoryService RepositoryService { get; set; }
    }
}