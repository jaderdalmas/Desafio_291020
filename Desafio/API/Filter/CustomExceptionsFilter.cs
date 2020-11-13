using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Api.Filter
{
    /// <summary>
    /// Custom Exception Filter
    /// </summary>
    public class CustomExceptionsFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="logger">Logger</param>
        public CustomExceptionsFilter(ILogger<CustomExceptionsFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// On Exception Pipeline
        /// </summary>
        /// <param name="context">Exception Context</param>
        public void OnException(ExceptionContext context)
        {
            if (context is null) return;

            _logger.LogError(context.Exception, context.Exception.Message, context.Exception.StackTrace);
        }
    }
}
