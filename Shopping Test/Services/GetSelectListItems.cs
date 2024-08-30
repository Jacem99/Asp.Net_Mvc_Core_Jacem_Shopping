
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Shopping_Test.Services
{

    public class GetSelectListItems : IGetSelectListItems
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IDistributedCache _distributedCache;

        /* private readonly DateTimeOffset _expiryTime = DateTimeOffset.Now.AddSeconds(30);
private readonly ICaching _cahing;*/

        public GetSelectListItems(ApplicationDbContext context , RoleManager<IdentityRole> roleManager , IDistributedCache distributedCache)
        {
            _dbContext = context;
            _roleManager = roleManager;
            _distributedCache = distributedCache;
            /* _cahing = cahing;*/

        }
        public async Task<IEnumerable<SelectListItem>> AgeStages()
        {
             List<SelectListItem> age = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.AgeStage)))
            {
                 age = await _dbContext.AgeStages
                           .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                           .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

              await  _distributedCache.SetStringAsync(NameModels.AgeStage, JsonConvert.SerializeObject(age));
                return age;
            }
           var getCash =await _distributedCache.GetStringAsync(NameModels.AgeStage);
            age = JsonConvert.DeserializeObject<List<SelectListItem>>(getCash);
            return age;

        }
        public async Task<IEnumerable<SelectListItem>> ClothsCalssification()
        {

            List<SelectListItem> cloths = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.ClothesClassification)))
            {
                cloths = await _dbContext.ClothesClassifications
              .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
              .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

                await _distributedCache.SetStringAsync(NameModels.ClothesClassification, JsonConvert.SerializeObject(cloths));
                return cloths;
            }
            var getCash = await _distributedCache.GetStringAsync(NameModels.ClothesClassification);
            cloths = JsonConvert.DeserializeObject<List<SelectListItem>>(getCash);
            return cloths;
        }
        public async Task<IEnumerable<SelectListItem>> HumanClass()
        {

            List<SelectListItem> human = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.HumanClass)))
            {
               human =  await _dbContext.HumanClass
              .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
              .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

                await _distributedCache.SetStringAsync(NameModels.HumanClass, JsonConvert.SerializeObject(human));
                return human;
            }
            var getCash = await _distributedCache.GetStringAsync(NameModels.HumanClass);
            human = JsonConvert.DeserializeObject<List<SelectListItem>>(getCash);
            return human;
         
        }
        public async Task<IEnumerable<SelectListItem>> Markas()
        {
            List<SelectListItem> marka = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.Marka)))
            {
                marka = await _dbContext.Markas
               .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
               .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

                await _distributedCache.SetStringAsync(NameModels.Marka, JsonConvert.SerializeObject(marka));
                return marka;
            }
            var getCash = await _distributedCache.GetStringAsync(NameModels.Marka);
            marka = JsonConvert.DeserializeObject<List<SelectListItem>>(getCash);
            return marka;
        }
        public async Task<IEnumerable<SelectListItem>> IdentityRoles()
        {
            List<SelectListItem> role = new List<SelectListItem>();

            if (string.IsNullOrEmpty(_distributedCache.GetString(NameModels.Roles)))
            {
                role = await _dbContext.Roles
               .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
               .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

                await _distributedCache.SetStringAsync(NameModels.Roles, JsonConvert.SerializeObject(role));
                return role;
            }
            var getCash = await _distributedCache.GetStringAsync(NameModels.Roles);
            role = JsonConvert.DeserializeObject<List<SelectListItem>>(getCash);
            return role;
            

        }

    } 
}
/*var casheData = _cahing.GetData<IEnumerable<IdentityRole>>(NameModels.Roles);
         if (casheData != null && casheData.Count() > 0)
             return casheData.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text);

         casheData = (IEnumerable<IdentityRole>?)*/

/*_cahing.SetData<IEnumerable<IdentityRole>>(NameModels.Roles, casheData, _expiryTime);
return (IEnumerable<SelectListItem>)casheData;*/