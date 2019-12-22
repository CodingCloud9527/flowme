using System;
using FlowMe.Engine.Configuration;

namespace FlowMe.Command.Context
{
    public class CommandContext
    {
        public Type CommandType { get; }

        public CommandContext(Type commandType, ProcessEngineConfiguration configuration)
        {
            Configuration = configuration;
            CommandType = commandType;
        }

        internal Exception CommandException { get; set; }

        public ProcessEngineConfiguration Configuration { get; }
    }
}