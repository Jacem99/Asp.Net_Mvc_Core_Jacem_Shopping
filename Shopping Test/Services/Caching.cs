
using StackExchange.Redis;

namespace Shopping_Test.Services
{
    public class Caching : ICaching
    {
        IDatabase _cachDb;
        public Caching()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:7089");
            _cachDb = redis.GetDatabase();
        }
        public object DeleteData<T>(string key) where T : class
        {
           var _exist = _cachDb.KeyExists(key);
            if( _exist ) 
                return _cachDb.KeyDelete(key);
            return false;
        }

        public T GetData<T>(string key) where T : class
        {
            var value = _cachDb.StringGet(key);
            if (!string.IsNullOrEmpty(value))
                return JsonSerializer.Deserialize<T>(value);
            return default;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime) where T : class
        {
            var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            return _cachDb.StringSet(key ,JsonSerializer.Serialize<T>(value), expiryTime);
        }
       
    }
}
