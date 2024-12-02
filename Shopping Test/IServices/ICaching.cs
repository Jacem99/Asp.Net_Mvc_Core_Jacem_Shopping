using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping_Test.IServices
{
    public interface ICaching 
    {
        Task<string> GetItems(string key);
        Task SetItems(string key, List<SelectListItem> Value);
        Task<List<SelectListItem>> GetItemsByDeserialize(string key);

       /* object DeleteData<T>(string key) where T : class;*/
    }
}
