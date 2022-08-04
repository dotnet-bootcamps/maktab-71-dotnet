var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddDistributedMemoryCache();


// *** Install-Package Microsoft.Extensions.Caching.SqlServer -Version 6.0.7
// *** dotnet sql-cache create "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DistCache;Integrated Security=True;" dbo TestCache
//builder.Services.AddDistributedSqlServerCache(options =>
//{
//    options.ConnectionString = builder.Configuration.GetConnectionString(
//        "DistCache_ConnectionString");
//    options.SchemaName = "dbo";
//    options.TableName = "TestCache";
//});

// *** Install-Package StackExchange.Redis -Version 2.6.48
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = builder.Configuration.GetConnectionString("MyRedisConStr");
//    options.InstanceName = "SampleInstance";
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
