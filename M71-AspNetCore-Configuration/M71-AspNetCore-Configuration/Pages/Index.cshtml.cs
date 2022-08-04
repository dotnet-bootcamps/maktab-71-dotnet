using M71_AspNetCore_Configuration.ConfigurationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace M71_AspNetCore_Configuration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppDomainOptions _appDomainSettings;
        private readonly IOptions<AppDomainOptions> _appDomainOptions;
        private readonly IOptionsSnapshot<AppDomainOptions> _appDomainOptionsSnapshot;
        private readonly AppSettings _appSettings;

        public IndexModel(
            ILogger<IndexModel> logger,
            IConfiguration configuration,
            AppDomainOptions appDomainSettings,
            IOptions<AppDomainOptions> appDomainOptions,
            IOptionsSnapshot<AppDomainOptions> appDomainOptionsSnapshot,
            AppSettings appSettings
            )
        {
            _logger = logger;
            _configuration = configuration;
            _appDomainSettings = appDomainSettings;
            _appDomainOptions = appDomainOptions;
            _appDomainOptionsSnapshot = appDomainOptionsSnapshot;
            _appSettings = appSettings;

            var options = _appDomainOptions.Value;
            var optionSnapshots = _appDomainOptionsSnapshot.Value;
        }

        public void OnGet()
        {
            var ApplicationName = _configuration.GetSection("AppDomain:ApplicationName").Value;
            var MaximumNumberOfOrdersPerDay = _configuration.GetSection("AppDomain:MaximumNumberOfOrdersPerDay").Value;
            var ApplicationIsShutdown = _configuration.GetSection("AppDomain:ApplicationIsShutdown").Value;

            
        }
    }
}