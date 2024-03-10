namespace Shopping_Test.IServices
{
    public interface ICaching
    {
        T Get<T>(string key) where T : class;
        bool SetData<T>(string key , T value ,DateTimeOffset expirationTime) where T : class;
        object DeleteData<T>(string key) where T : class;
    }
}
