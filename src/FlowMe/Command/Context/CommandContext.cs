using System;
using FlowMe.Engine.Configuration;

namespace FlowMe.Command.Context
{
    public class CommandContext
    {
        private readonly Type _commandType;
        internal Exception CommandException { get; set; }

        public CommandContext(Type commandType, ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
            _commandType = commandType;
        }

        public ProcessEngineConfiguration Configuration { get; }
    }
}