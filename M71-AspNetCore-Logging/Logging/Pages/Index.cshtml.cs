using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Logging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogTrace("Start Method {Method} by User {UserId}", nameof(OnGet), "1");
            //_logger.LogTrace("Test log");
            //_logger.LogTrace("Test log");
            //_logger.LogTrace("Test log");
            //_logger.LogTrace("Test log");
            //_logger.LogTrace("Test log");
            //_logger.LogTrace("Test log");
            //_logger.LogTrace("Test log");
            //_logger.LogTrace("Test log");
            _logger.LogInformation("Test log");
            _logger.LogWarning("Test log");
            _logger.LogError("Test log {Exception}", new Exception("ljsndklasdmklamsd; amd;lasmd;l mas;"));
            _logger.LogCritical("Test log");
            _logger.LogTrace("Finish Method {Method}", nameof(OnGet));
        }
    }
}