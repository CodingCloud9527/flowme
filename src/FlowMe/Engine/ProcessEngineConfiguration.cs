using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace FlowMe.Engine
{
    public class ProcessEngineConfiguration
    {
        ILogger Logger { get; set; } = NullLogger.Instance;
    }
}