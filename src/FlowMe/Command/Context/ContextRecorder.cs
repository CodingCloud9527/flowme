using System.Collections.Generic;
using System.Threading;
using Castle.Core.Internal;
using FlowMe.Engine.Configuration;

namespace FlowMe.Command.Context
{
    public class ContextRecorder
    {
        private static readonly AsyncLocal<Stack<CommandContext>> CommandContextStack = new AsyncLocal<Stack<CommandContext>>();

        private static readonly AsyncLocal<Stack<ProcessEngineConfiguration>> ConfigurationStack = new AsyncLocal<Stack<ProcessEngineConfiguration>>();

        public static CommandContext CommandContext
        {
            get
            {
                var commandContexts = OperateStack(CommandContextStack);
                return commandContexts.IsNullOrEmpty() ? null : commandContexts.Peek();
            }

            set => OperateStack(CommandContextStack).Push(value);
        }

        public static ProcessEngineConfiguration Configuration
        {
            get
            {
                var configurations = OperateStack(ConfigurationStack);
                return configurations.IsNullOrEmpty() ? null : configurations.Peek();
            }

            set => OperateStack(ConfigurationStack).Push(value);
        }

        private static Stack<T> OperateStack<T>(AsyncLocal<Stack<T>> asyncLocal)
        {
            var localStack = asyncLocal.Value;
            if (localStack == null)
            {
                localStack = new Stack<T>();
                asyncLocal.Value = localStack;
            }

            return localStack;
        }
    }
}