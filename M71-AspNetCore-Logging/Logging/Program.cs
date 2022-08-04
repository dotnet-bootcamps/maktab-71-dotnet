using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.serilog.json", false)
    .AddJsonFile("appsettings.Production.serilog.json", false)
    .AddJsonFile("appsettings.Test.serilog.json", false);

//if(builder.Environment.EnvironmentName=="Develpment")

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//builder.Logging.AddSeq("http://localhost:5341", "quauHxwX5cJ41jsqZztM");

//builder.Logging.AddSerilog()
builder.Logging.AddProvider(new SerilogLoggerProvider());
builder.Host.UseSerilog((hostingContext, provider, loggerConfiguration) =>
{
    //loggerConfiguration.ReadFrom.Configuration(builder.Configuration);
    //loggerConfiguration.WriteTo.ColoredConsole();
    loggerConfiguration.WriteTo.Seq("http://localhost:5341", apiKey: "quauHxwX5cJ41jsqZztM");
});

//builder.Host.ConfigureLogging(logging =>
//{
//    logging.ClearProviders();
//    logging.AddConsole();
//});


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


//var a = builder.Configuration["WorkHours:WorkDays"]

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
