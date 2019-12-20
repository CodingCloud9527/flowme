using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace FlowMe.Engine.Logger
{
    internal static class LoggerHolder
    {
        private static ILogger _logger;

        internal static ILogger Logger
        {
            get => _logger ?? NullLogger.Instance;

            set
            {
                lock (_logger)
                {
                    _logger = value;
                }
            }
        }
    }
}