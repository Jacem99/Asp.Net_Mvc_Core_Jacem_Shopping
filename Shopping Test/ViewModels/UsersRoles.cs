using Microsoft.AspNetCore.Identity;
using Shopping_Test.Models;
using System.ComponentModel.DataAnnotations;


namespace Shopping_Test.ViewModels
{
    public class UsersRoles
    {
        public ApplicationUser applicationUsers { get; set; } = default!;
        public IList<string> ApplicationUserRoles { get; set; } = new List<string>();

        [Display(Name ="Roles Name")]
        public string RoleName { get; set; } = string.Empty;

        [Display(Name = "Roles")]
        public IList<IdentityRole> roles { get; set; } = new List<IdentityRole>();
    }
}
