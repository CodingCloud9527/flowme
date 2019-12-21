using System;
using FlowMe.Engine.Configuration;

namespace FlowMe.Command.Context
{
    public class CommandContext
    {
        public ProcessEngineConfiguration Configuration { get; }
        private readonly Type _commandType;

        public CommandContext(Type commandType, ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
            _commandType = commandType;
        }
    }
}