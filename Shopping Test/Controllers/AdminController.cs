

namespace Shopping_Test.Controllers
{
    [Authorize(Roles = Permissions.Admin)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
