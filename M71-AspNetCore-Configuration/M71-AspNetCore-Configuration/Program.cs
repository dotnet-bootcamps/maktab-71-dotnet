using M71_AspNetCore_Configuration.ConfigurationModels;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


var basePath = builder.Environment.ContentRootPath;


builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.domain.json", false)
    .AddJsonFile("appSettings.serilog.json", false)
    .AddJsonFile("appSettings.tech.json", false)
    .AddJsonFile("appSettings.hotReload.json", false, true)
    .AddJsonFile("appSettings.custom.json", true)
    //.AddIniFile()
    //.AddXmlFile()
    //.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json")
    //.AddCommandLine()
    //.AddEnvironmentVariables()
    //.AddUserSecrets("78e6bb6e-baf0-4d31-a45e-6f65eb0cbba5")
    ;

var configs = builder.Configuration;


//var ApplicationName = configs.GetSection("AppDomain:ApplicationName").Value;
//var MaximumNumberOfOrdersPerDay = configs.GetSection("AppDomain:MaximumNumberOfOrdersPerDay").Value;
//var ApplicationIsShutdown = configs.GetSection("AppDomain:ApplicationIsShutdown").Value;

// use configure for using as IOption and IOptionSnapshot
//builder.Services.Configure<AppDomainOptions>(builder.Configuration.GetSection("AppDomain"));


//builder.Services.Configure<AppSettings>(builder.Configuration.Get<AppSettings>());
builder.Services.AddSingleton(builder.Configuration.Get<AppSettings>());
var appSettings = builder.Configuration.Get<AppSettings>();


//builder.Services.AddSingleton(builder.Configuration.GetSection("Logging").GetSection("LogLevel").Get<LogLevel>());

//var appDomainOptions = builder.Configuration.GetSection("AppDomain").Bind(AppDomainOptions)

var appDomainOptions = builder.Configuration.GetSection("AppDomain").Get<AppDomainOptions>();

var ConnectionString = configs.GetSection("ConnectionString").Value;
var MaximumOrders = configs.GetSection("MaximumOrders").Value;

var Username = configs.GetSection("SqlLogin").Value;
var Password = configs.GetSection("SqlPassword").Value;




builder.Services.AddRazorPages();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
