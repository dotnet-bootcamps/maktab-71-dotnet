namespace M71_AspNetCore_Configuration.ConfigurationModels
{
    public class AppDomainOptions
    {
        public string ApplicationName { get; set; }
        public int MaximumNumberOfOrdersPerDay { get; set; }
        public bool ApplicationIsShutdown { get; set; }
    }


    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Appdomain AppDomain { get; set; }
        public int MaximumOrders { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Appdomain
    {
        public string ApplicationName { get; set; }
        public int MaximumNumberOfOrdersPerDay { get; set; }
        public bool ApplicationIsShutdown { get; set; }
    }


}
