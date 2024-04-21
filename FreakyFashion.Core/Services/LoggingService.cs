using FreakyFashion.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace FreakyFashion.Core.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;
        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }
    
        public void LogError(Exception e)
        {
            _logger.LogError(e, e.Message);
        }

        public void LogInfo(string message)
        {
            _logger.LogWarning(message);
        }
    }
}