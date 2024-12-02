
namespace Shopping_Test.Services
{
    public class GetListItems : IGetListItems
    {
        private readonly ApplicationDbContext _dbContext;
        public GetListItems(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<SelectListItem>> AgeStages()=> await _dbContext.AgeStages
                           .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                           .AsNoTracking().OrderBy(c => c.Text).ToListAsync();
        
        public async Task<List<SelectListItem>> ClothsCalssification()=> await _dbContext.ClothesClassifications
                          .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                          .AsNoTracking().OrderBy(c => c.Text).ToListAsync();
        

        public async Task<List<SelectListItem>> HumanClass()
        {
            return await _dbContext.HumanClass
                          .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                          .AsNoTracking().OrderBy(c => c.Text).ToListAsync();
        }

        public async Task<List<SelectListItem>> IdentityRoles()=>await _dbContext.Roles.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).AsNoTracking().OrderBy(c => c.Text).ToListAsync();
        

        public async Task<List<SelectListItem>> Markas()=> await _dbContext.Markas.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).AsNoTracking().OrderBy(c => c.Text).ToListAsync();
        
    }
}
