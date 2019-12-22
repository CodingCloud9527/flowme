using System;
using FlowMe.Engine.Configuration;

namespace FlowMe.Command.Context
{
    public class CommandContext
    {
        private readonly Type _commandType;

        public CommandContext(Type commandType, ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
            _commandType = commandType;
        }

        internal Exception CommandException { get; set; }

        public ProcessEngineConfiguration Configuration { get; }
    }
}