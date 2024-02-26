
using Microsoft.EntityFrameworkCore;

namespace Shopping_Test.Services
{

    public class GetSelectListItems : IGetSelectListItems
    {
        private readonly ApplicationDbContext _dbContext;
        public GetSelectListItems(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<SelectListItem>> AgeStages() =>
            await _dbContext.AgeStages
           .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
             .OrderBy(c => c.Text)
           .ToListAsync();


        public async Task<IEnumerable<SelectListItem>> ClothsCalssification() =>
               await _dbContext.ClothesClassifications
             .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .OrderBy(c => c.Text)
             .ToListAsync();


        public async Task<IEnumerable<SelectListItem>> HumanClass() =>
             await _dbContext.HumanClass
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
             .OrderBy(c => c.Text)
            .ToListAsync();


        public async Task<IEnumerable<SelectListItem>> Markas() =>
             await _dbContext.Markas.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(c => c.Text)
           .ToListAsync();

    } 
}
