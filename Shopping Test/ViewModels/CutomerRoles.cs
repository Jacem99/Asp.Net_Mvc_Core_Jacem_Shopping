using Microsoft.AspNetCore.Identity;
using Shopping_Test.Models;

namespace Shopping_Test.ViewModels
{
    public class CutomerRoles
    {
        [Display(Name = "Roles")]
        public string Roles { get; set; } = string.Empty;
        public IEnumerable<SelectListItem> identityRoles { get; set; } = Enumerable.Empty<SelectListItem>(); //new List<IdentityRole>();
        public IEnumerable<ApplicationUser> applicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
