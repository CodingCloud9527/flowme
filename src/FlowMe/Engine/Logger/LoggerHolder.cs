using log4net;
using log4net.Config;

namespace FlowMe.Engine.Logger
{
    internal static class LoggerHolder
    {
        private static ILog _logger;

        internal static ILog Logger
        {
            get
            {
                if (_logger == null)
                {
                    var loggerRepository = LogManager.CreateRepository("FlowMe");
                    BasicConfigurator.Configure(loggerRepository);
                    _logger = LogManager.GetLogger(loggerRepository.Name, "FlowMe");
                }

                return _logger;
            }

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