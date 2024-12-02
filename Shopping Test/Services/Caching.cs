
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Data;

namespace Shopping_Test.Services
{
    public class Caching : ICaching

    {
        private readonly ApplicationDbContext _context;
        private readonly IDistributedCache _distributedCache;

        public Caching(ApplicationDbContext context,IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
        }

        public async Task<string> GetItems(string key)
        {
           return await _distributedCache.GetStringAsync(key);
                
        }
        public async Task<List<SelectListItem>> GetItemsByDeserialize(string key)
        {
            var itemKey = await _distributedCache.GetStringAsync(key);

            return JsonConvert.DeserializeObject<List<SelectListItem>>(itemKey);
        }

        public async Task SetItems(string key, List<SelectListItem> Value) 
        {
           await _distributedCache.SetStringAsync(key , JsonConvert.SerializeObject(Value)); 
        }

      
    }
}
