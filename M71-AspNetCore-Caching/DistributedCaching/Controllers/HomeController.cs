using DistributedCaching.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace DistributedCaching.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public HomeController(ILogger<HomeController> logger,
            //IMemoryCache memoryCache,
            IDistributedCache distributedCache)
        {
            _logger = logger;
            //_memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        public string Remove()
        {
            _distributedCache.Remove("Categories");
            return "removed succesfully";
        }

        public string Get()
        {
            var bytesOfCachedValue = _distributedCache.Get("Categories");

            if (bytesOfCachedValue != null)
            {

                var deserializedValue = JsonSerializer.Deserialize<int>(bytesOfCachedValue);
                return deserializedValue.ToString();
            }
            else
            {
                // get data from database and set in cache and return data
                return "There is no data in cache";

            }
        }

        public string Set()
        {
            var numberOfVisits = 100;
            var serializedValue = JsonSerializer.Serialize(numberOfVisits);
            var byesOfValue = Encoding.UTF8.GetBytes(serializedValue);

            // در این حالت بعد از 300 ثانیه کش حذف می شود
            _distributedCache.Set("Categories", byesOfValue);

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