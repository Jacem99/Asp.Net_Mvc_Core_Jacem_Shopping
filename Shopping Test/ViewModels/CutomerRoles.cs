using Microsoft.AspNetCore.Identity;
using Shopping_Test.Models;

namespace Shopping_Test.ViewModels
{
    public class CutomerRoles
    {
        public string Roles { get; set; } = string.Empty;
        public IEnumerable<IdentityRole> identityRoles { get; set; } = new List<IdentityRole>();
        public IEnumerable<ApplicationUser> applicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
