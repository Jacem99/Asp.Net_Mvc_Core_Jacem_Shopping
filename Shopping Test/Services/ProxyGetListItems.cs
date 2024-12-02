
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Shopping_Test.Services
{

    public class ProxyGetListItems : IProxyGetListItems
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IDistributedCache _distributedCache;
        private readonly IGetListItems _getListItems;
        private readonly ICaching _caching;

        public ProxyGetListItems(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, IDistributedCache distributedCache, ICaching caching, IGetListItems getListItems)
        {
            _dbContext = context;
            _roleManager = roleManager;
            _distributedCache = distributedCache;
            _caching = caching;
            _getListItems = getListItems;
        }
        public async Task<IEnumerable<SelectListItem>> AgeStages()
        {
             List<SelectListItem> age = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.AgeStages)))
            {
                age = await _getListItems.AgeStages();

                await  _caching.SetItems(NameModels.AgeStages, age);
                return age;
            }
           
            return await _caching.GetItemsByDeserialize(NameModels.AgeStages);
        }
        public async Task<IEnumerable<SelectListItem>> ClothsCalssification()
        {

            List<SelectListItem> cloths = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.ClothesClassification)))
            {
                cloths = await _getListItems.ClothsCalssification();

                await _caching.SetItems(NameModels.ClothesClassification,cloths);
                return cloths;
            }
           return await _caching.GetItemsByDeserialize(NameModels.ClothesClassification);
        }
        public async Task<IEnumerable<SelectListItem>> HumanClass()
        {

            List<SelectListItem> human = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.HumanClass)))
            {
                human = await _getListItems.HumanClass();
                await _caching.SetItems(NameModels.HumanClass, human);
                return human;
            }

            return await _caching.GetItemsByDeserialize(NameModels.HumanClass);
        }
        public async Task<IEnumerable<SelectListItem>> Markas()
        {
            List<SelectListItem> marka = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.Markas)))
            {
                marka = await _getListItems.Markas();
                await _caching.SetItems(NameModels.Markas, marka);
                return marka;
            }
          return await _caching.GetItemsByDeserialize(NameModels.Markas);
        }
        public async Task<IEnumerable<SelectListItem>> IdentityRoles()
        {
            List<SelectListItem> role = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.Roles)))
            {
                role = await _getListItems.IdentityRoles();

                await _distributedCache.SetStringAsync(NameModels.Roles, JsonConvert.SerializeObject(role));
                return role;
            }
           return await _caching.GetItemsByDeserialize(NameModels.Roles);
           
        }

      
    } 
}
