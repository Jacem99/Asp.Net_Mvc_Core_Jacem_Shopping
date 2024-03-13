
using Microsoft.EntityFrameworkCore;

namespace Shopping_Test.Services
{

    public class GetSelectListItems : IGetSelectListItems
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
       /* private readonly DateTimeOffset _expiryTime = DateTimeOffset.Now.AddSeconds(30);
        private readonly ICaching _cahing;*/
        public GetSelectListItems(ApplicationDbContext context , RoleManager<IdentityRole> roleManager/*, ICaching cahing*/)
        {
            _dbContext = context;
            _roleManager = roleManager;
         /*   _cahing = cahing;*/

        }
        public async Task<IEnumerable<SelectListItem>> AgeStages()
        {
         /* var casheData = _cahing.GetData<IEnumerable<AgeStage>>(NameModels.AgeStage);
          if (casheData != null && casheData.Count() > 0)
                return casheData.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text);*/

         /*casheData = (IEnumerable<AgeStage>?)*/return await _dbContext.AgeStages
           .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
           .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

        /*_cahing.SetData<IEnumerable<AgeStage>>(NameModels.AgeStage, casheData, _expiryTime);
         return (IEnumerable<SelectListItem>)casheData;*/
        }
        public async Task<IEnumerable<SelectListItem>> ClothsCalssification()
        {
            /*var casheData = _cahing.GetData<IEnumerable<ClothesClassification>>(NameModels.ClothesClassification);
            if (casheData != null && casheData.Count() > 0)
                return casheData.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text);*/

          /*  casheData = (IEnumerable<ClothesClassification>?)*/ return await _dbContext.ClothesClassifications
              .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
              .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

          /*  _cahing.SetData<IEnumerable<ClothesClassification>>(NameModels.ClothesClassification, casheData, _expiryTime);
            return (IEnumerable<SelectListItem>)casheData;*/
        }
        public async Task<IEnumerable<SelectListItem>> HumanClass()
        {
         /*   var casheData = _cahing.GetData<IEnumerable<HumanClass>>(NameModels.HumanClass);
            if (casheData != null && casheData.Count() > 0)
                return casheData.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text);*/

           /* casheData = (IEnumerable<HumanClass>?)*/ return await _dbContext.HumanClass
              .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
              .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

         /*  _cahing.SetData<IEnumerable<HumanClass>>(NameModels.HumanClass, casheData, _expiryTime);
            return (IEnumerable<SelectListItem>)casheData;*/
        }
        public async Task<IEnumerable<SelectListItem>> Markas()
        {
           /* var casheData = _cahing.GetData<IEnumerable<Marka>>(NameModels.Marka);
            if (casheData != null && casheData.Count() > 0)
                return casheData.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text);
*/
           /* casheData = (IEnumerable<Marka>?)*/ return await _dbContext.Markas
              .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
              .AsNoTracking().OrderBy(c => c.Text).ToListAsync();

           /* _cahing.SetData<IEnumerable<Marka>>(NameModels.Marka, casheData, _expiryTime);
            return (IEnumerable<SelectListItem>)casheData;*/
        }
        public async Task<IEnumerable<SelectListItem>> IdentityRoles()
        {
            /*var casheData = _cahing.GetData<IEnumerable<IdentityRole>>(NameModels.Roles);
            if (casheData != null && casheData.Count() > 0)
                return casheData.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text);*/

        /*    casheData = (IEnumerable<IdentityRole>?)*/ return await _roleManager.Roles.Select(c => new SelectListItem { Value = c.Name, Text = c.Name }).OrderBy(c => c.Text).AsNoTracking().ToListAsync();

         /*   _cahing.SetData<IEnumerable<IdentityRole>>(NameModels.Roles, casheData, _expiryTime);
            return (IEnumerable<SelectListItem>)casheData;*/
        }

    } 
}
