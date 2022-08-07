using Caching.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;


        public HomeController(ILogger<HomeController> logger, 
            IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public string Remove()
        {
             _memoryCache.Remove("Categories");
             return "removed succesfully";
        }

        public string Get()
        {
            return _memoryCache.Get<int>("Categories")
                .ToString();
        }

        public string Set()
        {
            //_memoryCache.Set("Categories", 5, DateTimeOffset.Now.AddSeconds(20));

            // در این حالت بعد از 300 ثانیه کش حذف می شود
            _memoryCache.Set("Categories", 5, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(300),
            });

            // بار هر بار فراخوانی 10 ثانیه کش تمدید می شود
            _memoryCache.Set("Categories", 5, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(10)
            });

            // زمان انقضا 300 ثانیه بعد است ولی اگر تا 10 ثانیه کسی از این 
            // آیتم استفاده نکند به صورت خودکار حذف می شود
            _memoryCache.Set("Categories", 5, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(300),
                SlidingExpiration = TimeSpan.FromSeconds(10)
            });

            return "it's ok";
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}