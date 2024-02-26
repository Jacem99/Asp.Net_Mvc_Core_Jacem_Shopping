﻿
namespace Shopping_Test.Controllers
{
/*   [Authorize(Roles ="Admin")]*/
    public class CustomerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        private readonly IUnitOfWork _unitOfWork;
        
        public CustomerController(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager,
           IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string? SearchCustomer , string? Roles)
        {
            
          //  await _userManager.GetUsersInRoleAsync(SearchCustomer),
            if (SearchCustomer != null)
            {
                SearchCustomer = SearchCustomer.ToLower().Trim();
                CutomerRoles cutomerRole = new CutomerRoles
                {
                    identityRoles = await _roleManager.Roles.AsNoTracking().ToListAsync(),
                    applicationUsers = await _unitOfWork.ApplictaionUsers
                    .GetAll(
                        a => a.Email == SearchCustomer ||
                        a.PhoneNumber.Contains(SearchCustomer) ||
                        a.DisplayName.Contains(SearchCustomer) ||
                        a.UserName == SearchCustomer,
                        a => a.DisplayName)
                };
             return View(cutomerRole);
            }
            if(Roles != null)
            {
                CutomerRoles cutomerRole = new CutomerRoles
                {
                    identityRoles = await _roleManager.Roles.AsNoTracking().ToListAsync(),
                    applicationUsers = await _userManager.GetUsersInRoleAsync(Roles),
                };
                return View(cutomerRole);
            }
            CutomerRoles cutomer = new CutomerRoles
            {
                identityRoles = null, /*await _roleManager.Roles.AsNoTracking().ToListAsync(),*/
                applicationUsers = null /*await _unitOfWork.ApplictaionUsers.GetAll(c => c.DisplayName)*/
            };
            return View(cutomer);
        }
     
        private async Task<UsersRoles> getUsersRole(ApplicationUser applicationUser)
        {
            var UsRol = await _userManager.GetRolesAsync(applicationUser);
            var rolesUsers = new UsersRoles
            {
                ApplicationUserRoles = UsRol,
                applicationUsers = applicationUser,
                roles = await _roleManager.Roles.OrderBy(r => r.Name).ToListAsync(),
            };
            return rolesUsers;
        }
        public async Task<IActionResult> RoleUser(string id)
        {
            if (id == null)
                return BadRequest();
            var user = await _unitOfWork.ApplictaionUsers.FindByCriteria(user => user.Id == id);
            if (user == null)
                return NotFound();
            var rolesUsers = await getUsersRole((ApplicationUser)user);
            return View(rolesUsers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleUser(UsersRoles usersRoles)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (usersRoles == null)
                return NotFound();
            var user = await _unitOfWork.ApplictaionUsers.FindByCriteria(user => user.Id == usersRoles.applicationUsers.Id);
            
            var UsRol = await _userManager.GetRolesAsync(user);

            if (UsRol.Contains(RoleUtilty.Admin))
            {
                if(usersRoles.RoleName == RoleUtilty.Admin && UsRol.Count == 1)
                {
                    ModelState.AddModelError("RoleName", "user already has this role. .! ");
                    return View(await getUsersRole(user));
                }
                ModelState.AddModelError("RoleName", "The Admin has all Role in site . .! ");
                return View(await getUsersRole(user));
            }
            if (usersRoles.RoleName == RoleUtilty.Admin)
                await _userManager.RemoveFromRolesAsync(user, UsRol);
            
            var result = await _userManager.AddToRoleAsync(user, usersRoles.RoleName);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("RoleName", "user already has this role! ");
                return View(await getUsersRole(user));
            }
            var rolesUsers = await getUsersRole(user);
            return View(rolesUsers);

        }
        public async Task<IActionResult> Delete(string id)
        {
           
            if (id == null)
                return BadRequest();

            IdentityUser? user = await _unitOfWork.ApplictaionUsers.FindByCriteria(user => user.Id == id);
            if (user == null)
                return NotFound();

            _unitOfWork.ApplictaionUsers.Remove((ApplicationUser)user);
            await _unitOfWork.Complete();
            if(!await _unitOfWork.ApplictaionUsers.CheckAny())
            {
                await _signInManager.SignOutAsync();
                return Ok("empty");
            }
            return Ok("");
        }
       
        public async Task<IActionResult> DeleteRoleUser(RemoveRoleUser removeRoleUser)
        {
            if (removeRoleUser == null)
                return BadRequest();
            var user = await _unitOfWork.ApplictaionUsers.FindByCriteria(user => user.Id == removeRoleUser.userId);
            if (user == null)
                return NotFound();

            await _userManager.RemoveFromRoleAsync((ApplicationUser)user, removeRoleUser.role);
            return Ok();
        }
        public async Task<IActionResult> Edit(string? Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user is null)
                return NotFound();
            
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser applicationUser)
        {
            var user = await _userManager.FindByIdAsync(applicationUser.Id) ;
               if(user is null)
            {
                ModelState.AddModelError("All", "Account Not Found !");
                return View(user);
            }
            var userExist = await _unitOfWork.ApplictaionUsers.FindByCriteria(e => e.Email == applicationUser.Email);
               if (userExist!=null && userExist.Email !=user.Email)
            {
                ModelState.AddModelError("All", "Email Exist !");
                return View(user);
            }
  
            if (user.Email == applicationUser.Email && user.FirstName == applicationUser.FirstName &&user.LastName ==applicationUser.LastName)
            {
                ModelState.AddModelError("All", "It's the Same Email !");
                return View(user);
            }

            user.Email = applicationUser.Email;
            user.UserName = new MailAddress(applicationUser.Email).User;
            user.FirstName = applicationUser.FirstName;
            user.LastName = applicationUser.LastName;

           await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }
    }
}